using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class GroupByRequestData : AggregationQueryRequestData
  {
    public string QueryType => "groupBy";
    public IEnumerable<IDimensionSpec> Dimensions { get; }
    public ILimitSpec LimitSpec { get; }
    public IHavingSpec HavingSpec { get; }
    public GroupByContextSpec Context { get; }

    public GroupByRequestData(object dataSource, object granularity, IList<string> intervals, IFilterSpec filter, GroupByContextSpec context, IEnumerable<IDimensionSpec> dimensions, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, ILimitSpec limitSpec, IHavingSpec havingSpec)
    {
      DataSource = dataSource;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Dimensions = dimensions;
      Aggregations = aggregations;
      PostAggregations = postAggregations;
      LimitSpec = limitSpec;
      HavingSpec = havingSpec;
    }
  }
}