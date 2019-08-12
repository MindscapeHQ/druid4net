using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class BasePostAggregator : IPostAggregationSpec
  {
    public abstract string Type { get; }

    public string Name { get; }
    
    public IEnumerable<IPostAggregationSpec> Fields { get; }
    
    protected BasePostAggregator(string name, IEnumerable<IPostAggregationSpec> fields)
    {
      Name = name;
      Fields = fields;
    }
    
    protected BasePostAggregator(string name, params IPostAggregationSpec[] fields)
    {
      Name = name;
      Fields = fields;
    }
  }
}