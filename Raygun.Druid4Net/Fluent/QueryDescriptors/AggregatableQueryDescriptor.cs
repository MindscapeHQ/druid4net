using System.Collections.Generic;
using Raygun.Druid4Net.Fluent.Aggregations;
using Raygun.Druid4Net.Fluent.PostAggreations;

namespace Raygun.Druid4Net
{
  public abstract class AggregatableQueryDescriptor : QueryDescriptor, IAggregatableQueryDescriptor
  {
    internal IEnumerable<IAggregationSpec> AggregationSpecsValue;

    internal IEnumerable<IPostAggregationSpec> PostAggregationSpecsValue;

    public IAggregatableQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }

    public IAggregatableQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }
  }
}
