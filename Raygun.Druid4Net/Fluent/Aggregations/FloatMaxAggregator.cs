namespace Raygun.Druid4Net
{
  public class FloatMaxAggregator : BaseAggregator
  {
    public override string Type => "floatMax";

    public FloatMaxAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}