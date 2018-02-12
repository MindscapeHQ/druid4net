namespace Raygun.Druid4Net
{
  public class EqualToHavingSpec : NumericHavingSpec
  {
    public override string Type => "equalTo";

    public EqualToHavingSpec(string aggregation, double value) : base(aggregation, value)
    { }
  }
}