namespace Raygun.Druid4Net
{
  public class LongAnyAggregator : BaseAggregator
  {
    public override string Type => "longAny";

    public LongAnyAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}