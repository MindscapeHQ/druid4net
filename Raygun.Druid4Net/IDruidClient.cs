using System;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IDruidClient
  {
    IQueryResponse<T> TopN<T>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where T : class;
    Task<IQueryResponse<T>> TopNAsync<T>(Func<IQueryDescriptor, ITopNQueryDescriptor> selector) where T : class;

    IQueryResponse<T> GroupBy<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class;
    Task<IQueryResponse<T>> GroupByAsync<T>(Func<IQueryDescriptor, IGroupByQueryDescriptor> selector) where T : class;

    IQueryResponse<T> Timeseries<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class;
    Task<IQueryResponse<T>> TimeseriesAsync<T>(Func<IQueryDescriptor, ITimeseriesQueryDescriptor> selector) where T : class;

    IQueryResponse<T> Select<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class;
    Task<IQueryResponse<T>> SelectAsync<T>(Func<IQueryDescriptor, ISelectQueryDescriptor> selector) where T : class;
  }
}
