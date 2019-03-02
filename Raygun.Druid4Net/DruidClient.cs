using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class DruidClient : IDruidClient
  {
    private readonly Requester _requester;
    private readonly string _apiEndpoint;

    public DruidClient(IJsonSerializer jsonSerializer, string hostName, int port = 8082, string apiEndpoint = "druid/v2")
    {
      _requester = new Requester(jsonSerializer, hostName, port);
      _apiEndpoint = apiEndpoint;
    }

    public IQueryResponse<TopNResult<TResponse>> TopN<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class
    {
      return TopNAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TopNResult<TResponse>>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new TopNQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TopNResult<TResponse>, TopNRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<GroupByResult<TResponse>> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      return GroupByAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<GroupByResult<TResponse>>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new GroupByQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<GroupByResult<TResponse>, GroupByRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<TimeseriesResult<TResponse>> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      return TimeseriesAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TimeseriesResult<TResponse>>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new TimeseriesQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TimeseriesResult<TResponse>, TimeseriesRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<SelectResult<TResponse>> Select<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      return SelectAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<SelectResult<TResponse>>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new SelectQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<SelectResult<TResponse>, SelectRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<SearchResult> Search(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector)
    {
      return SearchAsync(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<SearchResult>> SearchAsync(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector)
    {
      var request = selector(new SearchQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<SearchResult, SearchRequestData>(_apiEndpoint, request);

      return result;
    }

    public IQueryResponse<TimeBoundaryResult> TimeBoundary(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector)
    {
      return TimeBoundaryAsync(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TimeBoundaryResult>> TimeBoundaryAsync(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector)
    {
      var request = selector(new TimeBoundaryQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TimeBoundaryResult, TimeBoundaryRequestData>(_apiEndpoint, request);

      return result;
    }

    private async Task<IQueryResponse<TResponse>> ExecuteQueryAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request) 
      where TResponse : class
    {
      return await _requester.PostAsync<TResponse, TRequest>(endpoint, request);
    }
  }
}
