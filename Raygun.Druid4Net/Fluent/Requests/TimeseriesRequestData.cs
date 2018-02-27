using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeseriesRequestData
  {
    public string QueryType => "timeseries";
    public string DataSource { get; }
    public bool Descending { get; }
    public object Granularity { get; }
    public List<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public IEnumerable<IAggregationSpec> Aggregations { get; }
    public IEnumerable<IPostAggregationSpec> PostAggregations { get; }
    public IContextSpec Context { get; }

    public TimeseriesRequestData(string dataSource, bool descending, object granularity, List<string> intervals, IFilterSpec filter, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, IContextSpec context)
    {
      DataSource = dataSource;
      Descending = descending;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Aggregations = aggregations;
      PostAggregations = postAggregations;
      Context = context;
    }
  }
}