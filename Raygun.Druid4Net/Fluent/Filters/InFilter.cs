using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class InFilter<T> : IFilter where T : struct
  {
    public string Type => "in";

    public string Dimension { get; }

    public IEnumerable<T> Values;

    public InFilter(string dimension, IEnumerable<T> values)
    {
      Dimension = dimension;
      Values = values;
    }
  }
}
