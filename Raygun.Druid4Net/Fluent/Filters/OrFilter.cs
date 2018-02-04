using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class OrFilter : IFilterSpec
  {
    public string Type => "or";

    public IEnumerable<IFilterSpec> Fields;

    public OrFilter(IEnumerable<IFilterSpec> filters)
    {
      Fields = filters;
    }
  }
}
