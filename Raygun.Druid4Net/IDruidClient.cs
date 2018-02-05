using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<TResponse> TopN<TResponse>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;
    Task<IQueryResponse<TResponse>> TopNAsync<TResponse>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where TResponse : class;

    //IQueryResponse<T> GroupBy<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class;
    //Task<IQueryResponse<T>> GroupByAsync<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class;

    //IQueryResponse<T> Timeseries<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class;
    //Task<IQueryResponse<T>> TimeseriesAsync<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class;

    //IQueryResponse<T> Select<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class;
    //Task<IQueryResponse<T>> SelectAsync<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class;
  }
}
