using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class AggregationQueryRequestData : QueryRequestData
  {
    public IEnumerable<IAggregationSpec> Aggregations { get; internal set; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; internal set; }
  }
}