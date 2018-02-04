using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class Requester
  {
    private readonly HttpClient _client;

    public Requester(string host, int port)
    {
      _client = new HttpClient();
      _client.BaseAddress = new Uri($"{host}:{port}/");
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IQueryResponse<T>> PostAsync<T>(string endpoint, string query)
    {
      try
      {
        var response = await _client.PostAsJsonAsync(endpoint, query);
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsAsync<T>();

        var queryResponse = new DruidResponse<T>
        {
          Data = data,
          RequestData = new QueryRequestData
          {
            Address = _client.BaseAddress + endpoint,
            Method = "POST",
            Query = query
          }
        };

        return queryResponse;
      }
      catch (WebException e)
      {
        DruidClientException ex;
        if (e.Response != null)
        {
          using (var reader = new StreamReader(e.Response.GetResponseStream()))
          {
            var status = e.Status;
            var body = reader.ReadToEnd();

            if (body.Contains("ReadTimeoutException"))
            {
              ex = new DruidClientTimeoutException($"Request to {endpoint} timed out", e);
            }
            else
            {
              ex = new DruidClientException($"Failed request to {endpoint} with status {status}", e);
            }

            ex.Data.Add("response", body);
            ex.Data.Add("query", query);

            throw ex;
          }
        }

        ex = new DruidClientException($"Failed request to {endpoint}, no response was received", e);
        ex.Data.Add("query", query);

        throw ex;
      }
    }
  }
}
