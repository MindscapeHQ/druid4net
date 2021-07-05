using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class InFilter<T> : IFilterSpec
  {
    public string Type => "in";

    public string Dimension { get; }

    public IEnumerable<T> Values { get; }

    public InFilter(string dimension, IEnumerable<T> values)
    {
      Dimension = dimension;
      Values = values;
    }

    public InFilter(string dimension, params T[] values)
    {
      Dimension = dimension;
      Values = values;
    }
  }
}
