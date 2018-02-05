using Jil;

namespace Raygun.Druid4Net
{
  public class TopNRequest : IDruidRequest
  {
    public string Body { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ITopNQueryDescriptor
    {
      var qd = queryDescriptor as TopNQueryDescriptor;

      Body = JSON.SerializeDynamic(new
      {
        queryType = qd.QueryType,
        dataSource = qd.DataSourceValue,
        dimension = qd.DimensionValue,
        metric = qd.MetricSpecValue,
        granularity = qd.GranularityValue,
        threshold = qd.ThresholdValue,
        intervals = qd.IntervalsValue,
        filter = qd.FilterValue,
        aggregations = qd.AggregationSpecsValue,
        postAggregations = qd.PostAggregationSpecsValue,
        context = qd.ContextValue
      }, new Options(prettyPrint: false, excludeNulls: true, includeInherited: true));
    }
  }
}
