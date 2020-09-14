using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class LongLeastPostAggregator : BasePostAggregator
  {
    public override string Type => "longLeast";

    public LongLeastPostAggregator(string name, IEnumerable<IPostAggregationSpec> fields) 
      : base(name, fields)
    {
    }

    public LongLeastPostAggregator(string name, params IPostAggregationSpec[] fields) 
      : base(name, fields)
    {
    }
  }
}