using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class OrFilter : IFilter
  {
    public string Type => "or";

    public IEnumerable<IFilter> Fields;

    public OrFilter(IEnumerable<IFilter> filters)
    {
      Fields = filters;
    }
  }
}
