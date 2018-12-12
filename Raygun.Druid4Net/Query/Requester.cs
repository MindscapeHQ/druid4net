using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class Requester
  {
    private readonly IJsonSerializer _json;
    private readonly HttpClient _client;

    public Requester(IJsonSerializer json, string host, int port)
    {
      _json = json;
      _client = new HttpClient();
      _client.BaseAddress = new Uri($"{host}:{port}");
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
          ex = new DruidClientException($"Failed request to {endpoint} with status {response.StatusCode}", e);
        }

        if (errorResponse != null)
        {
          switch (errorResponse.ErrorClass)
          {
            case "io.druid.query.ResourceLimitExceededException":
              ex = new DruidResourceExceededException(errorResponse.ErrorMessage);
              break;

            case "io.druid.java.util.common.RE":
              if (errorResponse.ErrorMessage.Contains("ReadTimeoutException"))
              {
                ex = new DruidTimeoutException(errorResponse.ErrorMessage);
              }

              break;

            default:
              var message = errorResponse.ErrorMessage ?? errorResponse.Error;
              ex = new DruidClientException($"Failed request to {endpoint} with error: {message}");
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
