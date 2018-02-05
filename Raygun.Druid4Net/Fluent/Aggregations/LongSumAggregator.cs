namespace Raygun.Druid4Net.Fluent.Aggregations
{
  public class LongSumAggregator : SumAggregator
  {
    public override string Type => "longSum";

    public LongSumAggregator(string name, string fieldName) 
      : base (name, fieldName)
    {
    }
  }
}