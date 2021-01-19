namespace Raygun.Druid4Net
{
  public class TimeseriesRequest : IDruidRequest<TimeseriesRequestData>
  {
    public TimeseriesRequestData RequestData { get; private set; }

    public void Build<TQueryType>(TQueryType queryDescriptor) where TQueryType : ITimeseriesQueryDescriptor
    {
      var qd = queryDescriptor as TimeseriesQueryDescriptor;

      RequestData = new TimeseriesRequestData(qd.DataSourceValue, qd.VirtualColumnsValue, qd.DescendingValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.AggregationSpecsValue, qd.PostAggregationSpecsValue, qd.ContextValue);
    }
  }
}
