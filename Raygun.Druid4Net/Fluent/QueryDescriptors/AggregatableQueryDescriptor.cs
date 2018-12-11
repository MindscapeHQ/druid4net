using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class AggregatableQueryDescriptor<TRequest> : QueryDescriptor<TRequest>, IAggregatableQueryDescriptor where TRequest : QueryRequestData
  {
    internal IEnumerable<IAggregationSpec> AggregationSpecsValue;

    internal IEnumerable<IPostAggregationSpec> PostAggregationSpecsValue;

    public IAggregatableQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec)
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
