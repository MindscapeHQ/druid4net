namespace Raygun.Druid4Net
{
  public class LessThanHavingSpec : NumericHavingSpec
  {
    public override string Type => "lessThan";

    public LessThanHavingSpec(string aggregation, double value) : base(aggregation, value)
    { }
  }
}