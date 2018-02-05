namespace Raygun.Druid4Net.Fluent.Aggregations
{
  public class CountAggregator : IAggregationSpec
  {
    public string Type => "count";

    public string Name { get; }

    public CountAggregator(string name)
    {
      Name = name;
    }
  }
}