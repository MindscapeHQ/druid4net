using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class DruidClient : IDruidClient
  {
    private readonly IRequester _requester;
    private readonly ConfigurationOptions _configurationOptions;

    [Obsolete("Use the constructor that takes a ConfigurationOptions instance")]
    public DruidClient(IJsonSerializer jsonSerializer, string hostName, int port = 8082, string apiEndpoint = "druid/v2")
    {
      _configurationOptions = new ConfigurationOptions
      {
        JsonSerializer = jsonSerializer,
        QueryApiBaseAddress = new Uri($"{hostName}:{port}"),
        QueryApiEndpoint = apiEndpoint,
      };
      _requester = new Requester(_configurationOptions);
    }
    
    public DruidClient(ConfigurationOptions options, IRequester requester = null)
    {
      _configurationOptions = options;
      _requester = requester ?? new Requester(options);
    }

    public IQueryResponse<TopNResult<TResponse>> TopN<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class
    {
      return TopNAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TopNResult<TResponse>>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new TopNQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TopNResult<TResponse>, TopNRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }

    public IQueryResponse<GroupByResult<TResponse>> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      return GroupByAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<GroupByResult<TResponse>>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new GroupByQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<GroupByResult<TResponse>, GroupByRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }

    public IQueryResponse<TimeseriesResult<TResponse>> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      return TimeseriesAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TimeseriesResult<TResponse>>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new TimeseriesQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TimeseriesResult<TResponse>, TimeseriesRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }

    [Obsolete("The 'select' query has been removed since Druid 0.17.0, use 'scan' instead. See https://druid.apache.org/docs/latest/querying/select-query.html for more details.")]
    public IQueryResponse<SelectResult<TResponse>> Select<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      return SelectAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    [Obsolete("The 'select' query has been removed since Druid 0.17.0, use 'scan' instead. See https://druid.apache.org/docs/latest/querying/select-query.html for more details.")]
    public async Task<IQueryResponse<SelectResult<TResponse>>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new SelectQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<SelectResult<TResponse>, SelectRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }

    public IQueryResponse<SearchResult> Search(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector)
    {
      return SearchAsync(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<SearchResult>> SearchAsync(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector)
    {
      var request = selector(new SearchQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<SearchResult, SearchRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }

    public IQueryResponse<TimeBoundaryResult> TimeBoundary(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector)
    {
      return TimeBoundaryAsync(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<TimeBoundaryResult>> TimeBoundaryAsync(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector)
    {
      var request = selector(new TimeBoundaryQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<TimeBoundaryResult, TimeBoundaryRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }
	
	public IQueryResponse<ScanResult<TResponse>> Scan<TResponse>(Func<IScanQueryDescriptor, IScanQueryDescriptor> selector) where TResponse : class
    {
      return ScanAsync<TResponse>(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<ScanResult<TResponse>>> ScanAsync<TResponse>(Func<IScanQueryDescriptor, IScanQueryDescriptor> selector) where TResponse : class
    {
      var request = selector(new ScanQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<ScanResult<TResponse>, ScanRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }
    
    public IQueryResponse<SegmentMetadataResult> SegmentMetadata(Func<ISegmentMetadataQueryDescriptor, ISegmentMetadataQueryDescriptor> selector)
    {
      return SegmentMetadataAsync(selector).GetAwaiter().GetResult();
    }

    public async Task<IQueryResponse<SegmentMetadataResult>> SegmentMetadataAsync(Func<ISegmentMetadataQueryDescriptor, ISegmentMetadataQueryDescriptor> selector)
    {
      var request = selector(new SegmentMetadataQueryDescriptor()).Generate();

      var result = await ExecuteQueryAsync<SegmentMetadataResult, SegmentMetadataRequestData>(_configurationOptions.QueryApiEndpoint, request);

      return result;
    }
	
    private async Task<IQueryResponse<TResponse>> ExecuteQueryAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request) 
      where TResponse : class
      where TRequest : QueryRequestData
    {
      return await _requester.PostAsync<TResponse, TRequest>(endpoint, request);
    }
  }
}
