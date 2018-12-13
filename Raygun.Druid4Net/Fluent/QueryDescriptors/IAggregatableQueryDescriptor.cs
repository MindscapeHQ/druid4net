using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IAggregatableQueryDescriptor : IQueryDescriptor
  {
    IAggregatableQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec);
    
    IAggregatableQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec);

    IAggregatableQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec);
    
    IAggregatableQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);
  }
}