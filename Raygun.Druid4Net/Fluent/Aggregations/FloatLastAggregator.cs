namespace Raygun.Druid4Net
{
  public class FloatLastAggregator : BaseAggregator
  {
    public override string Type => "floatLast";

    public FloatLastAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}