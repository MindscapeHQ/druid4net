namespace Raygun.Druid4Net
{
  public class DoubleMinAggregator : BaseAggregator
  {
    public override string Type => "doubleMin";

    public DoubleMinAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}