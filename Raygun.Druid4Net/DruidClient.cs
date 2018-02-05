using System;
using System.Threading.Tasks;
using Jil;

namespace Raygun.Druid4Net
{
  public class DruidClient : IDruidClient
  {
    private readonly Requester _requester;

    private readonly string _apiEndpoint;

    public DruidClient(string hostName, int port, string apiEndpoint = "/druid/v2")
    {
      _requester = new Requester(hostName, port);
      _apiEndpoint = apiEndpoint;

      JSON.SetDefaultOptions(new Options(prettyPrint: false, excludeNulls: true, includeInherited: true, serializationNameFormat: SerializationNameFormat.CamelCase));
    }

    public IQueryResponse<T> TopN<T>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where T : class
    {
      return TopNAsync<T>(selector).Result;
    }

    public async Task<IQueryResponse<TResponse>> TopNAsync<TResponse>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class
    {
      var request = ((TopNQueryDescriptor)selector(new TopNQueryDescriptor())).Generate();

      var result = await ExecuteQueryAsync<TResponse, TopNRequestData>(_apiEndpoint, request);

      return result;
    }

    //public IQueryResponse<T> GroupBy<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class
    //{
    //  return GroupByAsync<T>(selector).Result;
    //}

    //public async Task<IQueryResponse<T>> GroupByAsync<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class
    //{
    //  IDruidRequest request = null;
    //  //var request = ((GroupByQueryDescriptor)selector(new GroupByQueryDescriptor())).Generate();

    //  var result = await ExecuteQueryAsync<T>(_apiEndpoint, request);

    //  return result;
    //}

    //public IQueryResponse<T> Timeseries<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class
    //{
    //  return TimeseriesAsync<T>(selector).Result;
    //}

    //public async Task<IQueryResponse<T>> TimeseriesAsync<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class
    //{
    //  IDruidRequest request = null;
    //  //var request = ((TimeseriesQueryDescriptor)selector(new TimeseriesQueryDescriptor())).Generate();

    //  var result = await ExecuteQueryAsync<T>(_apiEndpoint, request);

    //  return result;
    //}

    //public IQueryResponse<T> Select<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class
    //{
    //  return SelectAsync<T>(selector).Result;
    //}

    //public async Task<IQueryResponse<T>> SelectAsync<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class
    //{
    //  var request = ((SelectQueryDescriptor)selector(new SelectQueryDescriptor())).Generate();

    //  var result = await ExecuteQueryAsync<T>(_apiEndpoint, request);

    //  return result;
    //}

    private async Task<IQueryResponse<TResponse>> ExecuteQueryAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request) 
      where TResponse : class 
      where TRequest : class
    {
      var query = JSON.SerializeDynamic(request.RequestData);

      return await _requester.PostAsync<TResponse>(endpoint, query);
    }
  }
}
