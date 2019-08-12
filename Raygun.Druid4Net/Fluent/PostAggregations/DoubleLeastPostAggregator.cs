using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DoubleLeastPostAggregator : BasePostAggregator
  {
    public override string Type => "doubleLeast";

    public DoubleLeastPostAggregator(string name, IEnumerable<IPostAggregationSpec> fields) 
      : base(name, fields)
    {
    }

    public DoubleLeastPostAggregator(string name, params IPostAggregationSpec[] fields) 
      : base(name, fields)
    {
    }
  }
}