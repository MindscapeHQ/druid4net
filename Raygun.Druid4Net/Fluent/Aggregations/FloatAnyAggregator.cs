namespace Raygun.Druid4Net
{
  public class FloatAnyAggregator : BaseAggregator
  {
    public override string Type => "floatAny";

    public FloatAnyAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}