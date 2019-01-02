using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<TopNResult<TResponse>> TopN<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TopNResult<TResponse>>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<GroupByResult<TResponse>> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<GroupByResult<TResponse>>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TimeseriesResult<TResponse>> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TimeseriesResult<TResponse>>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<SelectResult<TResponse>> Select<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<SelectResult<TResponse>>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<SearchResult> Search(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector);
    Task<IQueryResponse<SearchResult>> SearchAsync(Func<ISearchQueryDescriptor, ISearchQueryDescriptor> selector);
  }
}
