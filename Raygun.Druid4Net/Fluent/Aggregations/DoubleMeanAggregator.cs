namespace Raygun.Druid4Net
{
  public class DoubleMeanAggregator : BaseAggregator
  {
    public override string Type => "doubleMean";

    public DoubleMeanAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}