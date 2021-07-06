using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class OrFilter : IFilterSpec
  {
    public string Type => "or";

    public IEnumerable<IFilterSpec> Fields { get; }

    public OrFilter(params IFilterSpec[] filters)
    {
      Fields = filters;
    }
    
    public OrFilter(IEnumerable<IFilterSpec> filters)
    {
      Fields = filters;
    }
  }
}
