namespace Raygun.Druid4Net
{
  public abstract class NumericHavingSpec : IHavingSpec
  {
    public abstract string Type { get; }

    public string Aggregation { get; }

    public double Value { get; }

    protected NumericHavingSpec(string aggregation, double value)
    {
      Aggregation = aggregation;
      Value = value;
    }
  }
}