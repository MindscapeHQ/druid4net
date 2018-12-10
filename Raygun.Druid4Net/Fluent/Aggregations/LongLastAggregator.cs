namespace Raygun.Druid4Net
{
  public class LongLastAggregator : BaseAggregator
  {
    public override string Type => "longLast";

    public LongLastAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}