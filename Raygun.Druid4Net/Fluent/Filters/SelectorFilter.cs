namespace Raygun.Druid4Net
{
  public class SelectorFilter : IFilterSpec
  {
    public string Type => "selector";

    public string Dimension { get; }

    public string Value { get; }

    public SelectorFilter(string dimension, string value)
    {
      Dimension = dimension;
      Value = value;
    }
  }
}