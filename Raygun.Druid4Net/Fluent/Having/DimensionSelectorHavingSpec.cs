namespace Raygun.Druid4Net
{
  public class DimensionSelectorHavingSpec : IHavingSpec
  {
    public string Type => "dimSelector";

    public string Aggregation { get; }

    public string Value { get; }

    public DimensionSelectorHavingSpec(string aggregation, string value)
    {
      Aggregation = aggregation;
      Value = value;
    }
  }
}