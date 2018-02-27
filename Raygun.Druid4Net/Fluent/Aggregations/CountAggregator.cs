namespace Raygun.Druid4Net
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