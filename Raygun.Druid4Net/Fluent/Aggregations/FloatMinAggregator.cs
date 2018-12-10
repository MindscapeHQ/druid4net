namespace Raygun.Druid4Net
{
  public class FloatMinAggregator : BaseAggregator
  {
    public override string Type => "floatMin";

    public FloatMinAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}