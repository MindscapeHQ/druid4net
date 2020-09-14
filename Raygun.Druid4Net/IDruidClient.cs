using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<TopNResult<TResponse>> TopN<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector);
    Task<IQueryResponse<TopNResult<TResponse>>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector);

    IQueryResponse<GroupByResult<TResponse>> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector);
    Task<IQueryResponse<GroupByResult<TResponse>>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector);

    IQueryResponse<TimeseriesResult<TResponse>> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector);
    Task<IQueryResponse<TimeseriesResult<TResponse>>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector);

    IQueryResponse<SelectResult<TResponse>> Select<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector);
    Task<IQueryResponse<SelectResult<TResponse>>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector);

    IQueryResponse<SearchResult> Search(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector);
    Task<IQueryResponse<SearchResult>> SearchAsync(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector);

    IQueryResponse<TimeBoundaryResult> TimeBoundary(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector);
    Task<IQueryResponse<TimeBoundaryResult>> TimeBoundaryAsync(Func<ITimeBoundaryQueryDescriptor, ITimeBoundaryQueryDescriptor> selector);
	
    IQueryResponse<ScanResult<TResponse>> Scan<TResponse>(Func<IScanQueryDescriptor, IScanQueryDescriptor> selector);
    Task<IQueryResponse<ScanResult<TResponse>>> ScanAsync<TResponse>(Func<IScanQueryDescriptor, IScanQueryDescriptor> selector);
    
    IQueryResponse<SegmentMetadataResult> SegmentMetadata(Func<ISegmentMetadataQueryDescriptor, ISegmentMetadataQueryDescriptor> selector);
    Task<IQueryResponse<SegmentMetadataResult>> SegmentMetadataAsync(Func<ISegmentMetadataQueryDescriptor, ISegmentMetadataQueryDescriptor> selector);
  }
}
