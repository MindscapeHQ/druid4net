using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class GroupByRequestData
  {
    public string QueryType => "groupBy";
    public object DataSource { get; }
    public object Granularity { get; }
    public List<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public IContextSpec Context { get; }
    public IEnumerable<string> Dimensions { get; }
    public IEnumerable<string> Metrics { get; }
    public IEnumerable<IAggregationSpec> Aggregations { get; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; }
    public ILimitSpec LimitSpec { get; }
    public IHavingSpec HavingSpec { get; }

    public GroupByRequestData(object dataSource, object granularity, List<string> intervals, IFilterSpec filter, IContextSpec context, IEnumerable<string> dimensions, IEnumerable<string> metrics, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, ILimitSpec limitSpec, IHavingSpec havingSpec)
    {
      DataSource = dataSource;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Dimensions = dimensions;
      Metrics = metrics;
      Aggregations = aggregations;
      PostAggregations = postAggregations;
      LimitSpec = limitSpec;
      HavingSpec = havingSpec;
    }
  }
}