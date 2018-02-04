using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class AndFilter : IFilter
  {
    public string Type => "and";

    public IEnumerable<IFilter> Fields;

    public AndFilter(IEnumerable<IFilter> filters)
    {
      Fields = filters;
    }
  }
}
