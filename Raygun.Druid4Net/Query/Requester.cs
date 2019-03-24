using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class Requester : IRequester
  {
    private readonly IJsonSerializer _json;
    private readonly HttpClient _client;

    public Requester(ConfigurationOptions options)
    {
      _json = options.JsonSerializer;
      _client = CreateClient(options);

      ConfigureClientAuthentication(_client, options);
    }

    private void ConfigureClientAuthentication(HttpClient client, ConfigurationOptions options)
    {
      if (options.BasicAuthenticationCredentials != null && !string.IsNullOrEmpty(options.BasicAuthenticationCredentials.ToString()))
      {
        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(options.BasicAuthenticationCredentials.ToString()));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
      }
    }

    private HttpClient CreateClient(ConfigurationOptions options)
    {
      var client = options.ProxySettings != null ? CreateClientWithProxyServer(options) : new HttpClient();
      client.BaseAddress = options.QueryApiBaseAddress;
      return client;
    }

    private HttpClient CreateClientWithProxyServer(ConfigurationOptions options)
    {
#if (NETSTANDARD1_6) 
      var httpClientHandler = new HttpClientHandler
      {
        UseProxy = true
      };
#else
      var webProxy = new WebProxy
      {
        Address = options.ProxySettings.Address,
        BypassProxyOnLocal = options.ProxySettings.BypassOnLocal,
        UseDefaultCredentials = true
      };

      if (!string.IsNullOrEmpty(options.ProxySettings.Username) && !string.IsNullOrEmpty(options.ProxySettings.Password))
      {
        webProxy.UseDefaultCredentials = false;
        webProxy.Credentials = new NetworkCredential(options.ProxySettings.Username, options.ProxySettings.Password);
      }

      var httpClientHandler = new HttpClientHandler
      {
        UseProxy = true,
        Proxy = webProxy
      };
#endif
      
      return new HttpClient(httpClientHandler, true);
    }

    public async Task<IQueryResponse<TResponse>> PostAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request)
      where TResponse : class
      where TRequest : QueryRequestData
    {
      var requestString = _json.Serialize(request.RequestData);

      var response = await _client.PostAsync(endpoint, new StringContent(requestString, Encoding.UTF8, "application/json"));

      if (response.IsSuccessStatusCode)
      {
        var responseString = await response.Content.ReadAsStringAsync();
        var data = _json.Deserialize<TResponse>(responseString);

        var queryResponse = new DruidResponse<TResponse>
        {
          Data = data,
          RequestData = new DruidQueryRequestData
          {
            Address = _client.BaseAddress + endpoint,
            Method = "POST",
            Query = requestString
          }
        };

        return queryResponse;
      }
      else
      {
        // Error or timeout, try and read the error response (if any)
        Exception ex = new DruidClientException($"Failed request to {_client.BaseAddress}{endpoint} with status {response.StatusCode}");
        ErrorResponse errorResponse = null;

        try
        {
          var responseString = await response.Content.ReadAsStringAsync();
          errorResponse = _json.Deserialize<ErrorResponse>(responseString);
        }
        catch (Exception e)
        {
          ex = new DruidClientException($"Failed request to {_client.BaseAddress}{endpoint} with status {response.StatusCode}", e);
        }

        if (errorResponse != null)
        {
          switch (errorResponse.ErrorClass)
          {
            case "io.druid.query.ResourceLimitExceededException":
              ex = new DruidResourceExceededException(errorResponse.ErrorMessage);
              break;

            case "com.fasterxml.jackson.databind.JsonMappingException":
              ex = new DruidJsonMappingException(errorResponse.ErrorMessage);
              break;

            case "io.druid.java.util.common.RE":
              if (errorResponse.ErrorMessage.Contains("ReadTimeoutException"))
              {
                ex = new DruidTimeoutException(errorResponse.ErrorMessage);
              }

              break;

            default:
              var message = errorResponse.ErrorMessage ?? errorResponse.Error;
              ex = new DruidClientException($"Failed request to {_client.BaseAddress}{endpoint} {message}");
              break;
          }

          ex.Data["host"] = errorResponse.Host;
          ex.Data["error"] = errorResponse.Error;
        }

        ex.Data["query"] = requestString;
        throw ex;
      }
    }
  }
}
