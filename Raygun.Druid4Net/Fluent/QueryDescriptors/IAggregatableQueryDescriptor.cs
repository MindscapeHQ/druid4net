using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IAggregatableQueryDescriptor : IQueryDescriptor
  {
    IAggregatableQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec);

    IAggregatableQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);
  }
}