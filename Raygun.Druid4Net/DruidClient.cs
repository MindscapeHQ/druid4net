using System;
using System.Threading.Tasks;

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

    public IQueryResponse<TResponse> GroupBy<TResponse>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      return GroupByAsync<TResponse>(selector).Result;
    }

    public async Task<IQueryResponse<TResponse>> GroupByAsync<TResponse>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      var request = ((GroupByQueryDescriptor)selector(new GroupByQueryDescriptor())).Generate();

      var result = await ExecuteQueryAsync<TResponse, GroupByRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<TResponse> Timeseries<TResponse>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      return TimeseriesAsync<TResponse>(selector).Result;
    }

    public async Task<IQueryResponse<TResponse>> TimeseriesAsync<TResponse>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      var request = ((TimeseriesQueryDescriptor)selector(new TimeseriesQueryDescriptor())).Generate();

      var result = await ExecuteQueryAsync<TResponse, TimeseriesRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<TResponse> Select<TResponse>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      return SelectAsync<TResponse>(selector).Result;
    }

    public async Task<IQueryResponse<TResponse>> SelectAsync<TResponse>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      var request = ((SelectQueryDescriptor)selector(new SelectQueryDescriptor())).Generate();

      var result = await ExecuteQueryAsync<TResponse, SelectRequestData>(_apiEndpoint, request);

      return result;
    }

    private async Task<IQueryResponse<TResponse>> ExecuteQueryAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request) 
      where TResponse : class 
      where TRequest : class
    {
      return await _requester.PostAsync<TResponse, TRequest>(endpoint, request);
    }
  }
}
