using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class AggregatableQueryDescriptor : QueryDescriptor
  {
    internal IEnumerable<IAggregationSpec> AggregationSpecsValue;

    internal IEnumerable<IPostAggregationSpec> PostAggregationSpecsValue;
  }
}
