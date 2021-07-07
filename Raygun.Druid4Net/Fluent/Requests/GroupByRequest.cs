namespace Raygun.Druid4Net
{
  internal class GroupByRequest : IDruidRequest<GroupByRequestData>
  {
    public GroupByRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : IGroupByQueryDescriptor
    {
      var qd = queryDescriptor as GroupByQueryDescriptor;

      RequestData = new GroupByRequestData(qd.DataSourceValue, qd.VirtualColumnsValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.DimensionsValue, qd.AggregationSpecsValue, qd.PostAggregationSpecsValue, qd.LimitSpecValue, qd.HavingSpecValue);
    }
  }
}
