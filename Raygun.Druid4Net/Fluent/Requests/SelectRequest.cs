using Jil;

namespace Raygun.Druid4Net
{
  public class SelectRequest : IDruidRequest
  {
    public string Body { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ISelectQueryDescriptor
    {
      var qd = queryDescriptor as SelectQueryDescriptor;

      Body = JSON.Serialize(new
      {
        queryType = qd.QueryType,
        dataSource = qd.DataSourceValue,
        granularity = qd.GranularityValue,
        intervals = qd.IntervalsValue,
        filter = qd.FilterValue,
        context = qd.ContextValue,
        dimensions = qd.DimensionsValue,
        metrics = qd.MetricsValue,
        pagingSpec = qd.PagingSpecValue,
        descending = qd.DescendingValue
      });
    }
  }
}
