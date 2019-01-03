namespace Raygun.Druid4Net
{
  public class DoubleSumAggregator : BaseAggregator
  {
    public override string Type => "doubleSum";

    public DoubleSumAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}