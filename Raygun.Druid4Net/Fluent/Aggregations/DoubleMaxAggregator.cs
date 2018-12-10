namespace Raygun.Druid4Net
{
  public class DoubleMaxAggregator : BaseAggregator
  {
    public override string Type => "doubleMax";

    public DoubleMaxAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}