using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class AggregatableQueryDescriptor<TResponse> : QueryDescriptor<TResponse>, IAggregatableQueryDescriptor where TResponse : class
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
