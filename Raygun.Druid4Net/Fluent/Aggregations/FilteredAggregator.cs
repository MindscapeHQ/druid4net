namespace Raygun.Druid4Net
{
  public class FilteredAggregator : IAggregationSpec
  {
    public string Type => "filtered";

    public IFilterSpec Filter { get; }
    
    public IAggregationSpec Aggregator { get; }

    public FilteredAggregator(IFilterSpec filter, IAggregationSpec aggregator)
    {
      Filter = filter;
      Aggregator = aggregator;
    }
  }
}