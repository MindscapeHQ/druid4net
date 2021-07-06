using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class AndFilter : IFilterSpec
  {
    public string Type => "and";

    public IEnumerable<IFilterSpec> Fields { get; }

    public AndFilter(params IFilterSpec[] filters)
    {
      Fields = filters;
    }
    
    public AndFilter(IEnumerable<IFilterSpec> filters)
    {
      Fields = filters;
    }
  }
}
