namespace Raygun.Druid4Net
{
  public class DoubleLastAggregator : BaseAggregator
  {
    public override string Type => "doubleLast";

    public DoubleLastAggregator(string name, string fieldName = null) 
      : base (name, fieldName)
    {
    }
  }
}