using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DoubleGreatestPostAggregator : BasePostAggregator
  {
    public override string Type => "doubleGreatest";

    public DoubleGreatestPostAggregator(string name, IEnumerable<IPostAggregationSpec> fields) 
      : base(name, fields)
    {
    }

    public DoubleGreatestPostAggregator(string name, params IPostAggregationSpec[] fields) 
      : base(name, fields)
    {
    }
  }
}