using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNRequestData
  {
    public string QueryType { get; }
    public string DataSource { get; }
    public string Dimension { get; }
    public ITopNMetricSpec Metric { get; }
    public object Granularity { get; }
    public long Threshold { get; }
    public List<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public IEnumerable<IAggregationSpec> Aggregations { get; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; }
    public ContextSpec Context { get; }

    public TopNRequestData(string queryType, string dataSource, string dimension, ITopNMetricSpec metric, object granularity, long threshold, List<string> intervals, IFilterSpec filter, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, ContextSpec context)
    {
      QueryType = queryType;
      DataSource = dataSource;
      Dimension = dimension;
      Metric = metric;
      Granularity = granularity;
      Threshold = threshold;
      Intervals = intervals;
      Filter = filter;
      Aggregations = aggregations;
      PostAggregations = postAggregations;
      Context = context;
    }
  }
}