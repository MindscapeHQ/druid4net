namespace Raygun.Druid4Net
{
  public class FloatFirstAggregator : BaseAggregator
  {
    public override string Type => "floatFirst";

    public FloatFirstAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}