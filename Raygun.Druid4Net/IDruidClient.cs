using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<TResponse> TopN<TResponse>(Func<ITopNQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> TopNAsync<TResponse>(Func<ITopNQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> GroupBy<TResponse>(Func<IGroupByQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> GroupByAsync<TResponse>(Func<IGroupByQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> Timeseries<TResponse>(Func<ITimeseriesQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> TimeseriesAsync<TResponse>(Func<ITimeseriesQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;

    IQueryResponse<TResponse> Select<TResponse>(Func<ISelectQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> SelectAsync<TResponse>(Func<ISelectQueryDescriptor, IQueryDescriptor> selector) where TResponse : class;
  }
}
