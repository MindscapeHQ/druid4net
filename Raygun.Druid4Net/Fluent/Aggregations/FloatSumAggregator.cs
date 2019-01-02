namespace Raygun.Druid4Net
{
  public class FloatSumAggregator : BaseAggregator
  {
    public override string Type => "floatSum";

    public FloatSumAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}