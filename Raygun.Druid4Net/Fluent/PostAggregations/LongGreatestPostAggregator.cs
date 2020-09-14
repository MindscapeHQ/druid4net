using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class LongGreatestPostAggregator : BasePostAggregator
  {
    public override string Type => "longGreatest";

    public LongGreatestPostAggregator(string name, IEnumerable<IPostAggregationSpec> fields) 
      : base(name, fields)
    {
    }

    public LongGreatestPostAggregator(string name, params IPostAggregationSpec[] fields) 
      : base(name, fields)
    {
    }
  }
}