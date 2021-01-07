using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class AggregationQueryRequestData : VirtualColumnQueryRequestData
  {
    public IEnumerable<IAggregationSpec> Aggregations { get; internal set; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; internal set; }
  }
}
