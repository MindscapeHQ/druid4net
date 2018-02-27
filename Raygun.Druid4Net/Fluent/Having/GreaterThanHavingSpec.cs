namespace Raygun.Druid4Net
{
  public class GreaterThanHavingSpec : NumericHavingSpec
  {
    public override string Type => "greaterThan";

    public GreaterThanHavingSpec(string aggregation, double value) : base(aggregation, value)
    { }
  }
}