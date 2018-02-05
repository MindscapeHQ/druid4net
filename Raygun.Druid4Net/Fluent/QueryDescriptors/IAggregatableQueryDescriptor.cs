using System.Collections.Generic;
using Raygun.Druid4Net.Fluent.Aggregations;
using Raygun.Druid4Net.Fluent.PostAggreations;

namespace Raygun.Druid4Net
{
  public interface IAggregatableQueryDescriptor : IQueryDescriptor
  {
    IAggregatableQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec);

    IAggregatableQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);
  }
}