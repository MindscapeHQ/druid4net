namespace Raygun.Druid4Net
{
  public class SelectorFilter<T> : IFilter where T : struct
  {
    public string Type => "selector";

    public string Dimension { get; }

    public T Value { get; }

    public SelectorFilter(string dimension, T value)
    {
      Dimension = dimension;
      Value = value;
    }
  }
}