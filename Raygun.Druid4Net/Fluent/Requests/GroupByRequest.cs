namespace Raygun.Druid4Net
{
  internal class GroupByRequest : IDruidRequest<GroupByRequestData>
  {
    public GroupByRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : IGroupByQueryDescriptor
    {
      var qd = queryDescriptor as GroupByQueryDescriptor;

      object datasource = qd.DataSourceValue;

      if (qd.InnerDataSourceValue != null)
      {
        var innerQd = qd.InnerDataSourceValue as GroupByQueryDescriptor;
        var innerQdRequest = new GroupByRequestData(innerQd.DataSourceValue, innerQd.VirtualColumnsValue, innerQd.GranularityValue, innerQd.IntervalsValue, innerQd.FilterValue, innerQd.ContextValue, innerQd.DimensionsValue, innerQd.AggregationSpecsValue, innerQd.PostAggregationSpecsValue, innerQd.LimitSpecValue, innerQd.HavingSpecValue);

        datasource = new InnerGroupByQueryRequestData(innerQdRequest);
      }

      RequestData = new GroupByRequestData(datasource, qd.VirtualColumnsValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.DimensionsValue, qd.AggregationSpecsValue, qd.PostAggregationSpecsValue, qd.LimitSpecValue, qd.HavingSpecValue);
    }
  }
}