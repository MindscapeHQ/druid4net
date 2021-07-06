namespace Raygun.Druid4Net
{
  public class DoubleAnyAggregator : BaseAggregator
  {
    public override string Type => "doubleAny";

    public DoubleAnyAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}