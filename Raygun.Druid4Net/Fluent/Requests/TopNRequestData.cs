using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNRequestData
  {
    public string QueryType => "topN";
    public string DataSource { get; }
    public string Dimension { get; }
    public ITopNMetricSpec Metric { get; }
    public object Granularity { get; }
    public long Threshold { get; }
    public IList<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public IEnumerable<IAggregationSpec> Aggregations { get; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; }
    public TopNContextSpec Context { get; }

    public TopNRequestData(string dataSource, string dimension, ITopNMetricSpec metric, object granularity, long threshold, IList<string> intervals, IFilterSpec filter, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, TopNContextSpec context)
    {
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