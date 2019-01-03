namespace Raygun.Druid4Net
{
  public class LongFirstAggregator : BaseAggregator
  {
    public override string Type => "longFirst";

    public LongFirstAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}