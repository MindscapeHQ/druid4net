using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class GroupByRequestData : AggregationQueryRequestData
  {
    public string QueryType => "groupBy";
    public object Granularity { get; }
    public IList<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public IEnumerable<IDimensionSpec> Dimensions { get; }
    public ILimitSpec LimitSpec { get; }
    public IHavingSpec Having { get; }
    public GroupByContextSpec Context { get; }

    public GroupByRequestData(IDataSourceSpec dataSource, IEnumerable<ExpressionVirtualColumn> virtualColumns, object granularity, IList<string> intervals, IFilterSpec filter, GroupByContextSpec context, IEnumerable<IDimensionSpec> dimensions, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, ILimitSpec limitSpec, IHavingSpec havingSpec)
    {
      DataSource = dataSource;
      VirtualColumns = virtualColumns;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Dimensions = dimensions;
      Aggregations = aggregations;
      PostAggregations = postAggregations;
      LimitSpec = limitSpec;
      Having = havingSpec;
    }
  }
}
