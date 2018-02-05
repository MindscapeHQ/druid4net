using Jil;

namespace Raygun.Druid4Net
{
  public class SelectRequest : IDruidRequest<SelectRequestData>
  {
    public SelectRequestData RequestData { get; private set; }

    public string Body { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ISelectQueryDescriptor
    {
      var qd = queryDescriptor as SelectQueryDescriptor;

      RequestData = new SelectRequestData(qd.QueryType, qd.DataSourceValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.DimensionsValue, qd.MetricsValue, qd.PagingSpecValue, qd.DescendingValue);
      Body = JSON.Serialize(RequestData);
    }
  }
}
