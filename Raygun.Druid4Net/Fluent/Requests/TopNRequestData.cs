using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNRequestData : AggregationQueryRequestData
  {
    public string QueryType => "topN";
    public IDimensionSpec Dimension { get; }
    public ITopNMetricSpec Metric { get; }
    public long Threshold { get; }
    public TopNContextSpec Context { get; }

    public TopNRequestData(string dataSource, IEnumerable<ExpressionVirtualColumn> virtualColumns, IDimensionSpec dimension, ITopNMetricSpec metric, object granularity, long threshold, IList<string> intervals, IFilterSpec filter, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, TopNContextSpec context)
    {
      DataSource = dataSource;
      VirtualColumns = virtualColumns;
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
