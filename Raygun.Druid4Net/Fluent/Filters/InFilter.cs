using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class InFilter<T> : IFilterSpec where T : struct
  {
    public string Type => "in";

    public string Dimension { get; }

    public IEnumerable<T> Values;

    public InFilter(string dimension, params T[] values)
    {
      Dimension = dimension;
      Values = values;
    }
  }
}
