namespace Raygun.Druid4Net
{
  internal class SelectRequest : IDruidRequest<SelectRequestData>
  {
    public SelectRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ISelectQueryDescriptor
    {
      var qd = queryDescriptor as SelectQueryDescriptor;

      RequestData = new SelectRequestData(qd.DataSourceValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.DimensionsValue, qd.MetricsValue, qd.PagingSpecValue, qd.DescendingValue);
    }
  }
}
