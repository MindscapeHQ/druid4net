using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Jil;

namespace Raygun.Druid4Net
{
  public class Requester
  {
    private readonly HttpClient _client;
    private readonly Options _jsonOptions;

    public Requester(string host, int port)
    {
      _client = new HttpClient();
      _client.BaseAddress = new Uri($"{host}:{port}/");
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      _jsonOptions = new Options(prettyPrint: false, excludeNulls: true, includeInherited: true, serializationNameFormat: SerializationNameFormat.CamelCase);
    }

    public async Task<IQueryResponse<TResponse>> PostAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request)
      where TResponse : class
      where TRequest : class
    {
      //try
      //{

      var requestString = JSON.SerializeDynamic(request.RequestData, _jsonOptions);
      var response = await _client.PostAsync(endpoint, new StringContent(requestString));

      response.EnsureSuccessStatusCode();

      var responseString = await response.Content.ReadAsStringAsync();
      var data = JSON.Deserialize<TResponse>(responseString);

      var queryResponse = new DruidResponse<TResponse>
      {
        Data = data,
        RequestData = new QueryRequestData
        {
          Address = _client.BaseAddress + endpoint,
          Method = "POST",
          Query = requestString
        }
      };

      return queryResponse;

      //}
      //catch (WebException e)
      //{
      //  DruidClientException ex;
      //  if (e.Response != null)
      //  {
      //    using (var reader = new StreamReader(e.Response.GetResponseStream()))
      //    {
      //      var status = e.Status;
      //      var body = reader.ReadToEnd();

      //      if (body.Contains("ReadTimeoutException"))
      //      {
      //        ex = new DruidClientTimeoutException($"Request to {endpoint} timed out", e);
      //      }
      //      else
      //      {
      //        ex = new DruidClientException($"Failed request to {endpoint} with status {status}", e);
      //      }

      //      ex.Data.Add("response", body);
      //      ex.Data.Add("query", query);

      //      throw ex;
      //    }
      //  }

      //  ex = new DruidClientException($"Failed request to {endpoint}, no response was received", e);
      //  ex.Data.Add("query", query);

      //  throw ex;
      //}
    }
  }
}
