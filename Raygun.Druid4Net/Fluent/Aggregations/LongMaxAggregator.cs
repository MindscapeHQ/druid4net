namespace Raygun.Druid4Net
{
  public class LongMaxAggregator : BaseAggregator
  {
    public override string Type => "longMax";

    public LongMaxAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}