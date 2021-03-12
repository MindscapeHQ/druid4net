namespace Raygun.Druid4Net
{
  public class DimensionSelectorHavingSpec : IHavingSpec
  {
    public string Type => "dimSelector";

    public string Dimension { get; }

    public string Value { get; }

    public DimensionSelectorHavingSpec(string dimension, string value)
    {
      Dimension = dimension;
      Value = value;
    }
  }
}