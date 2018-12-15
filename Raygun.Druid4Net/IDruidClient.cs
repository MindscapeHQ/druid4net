using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<TResponse> TopN<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, ITimeseriesQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> Select<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, ISelectQueryDescriptor> selector) where TResponse : class;
  }
}
