﻿using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeseriesRequestData : AggregationQueryRequestData
  {
    public string QueryType => "timeseries";
    public object Granularity { get; }
    public IList<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public bool Descending { get; }
    public TimeseriesContextSpec Context { get; }

    public TimeseriesRequestData(IDataSourceSpec dataSource, IEnumerable<ExpressionVirtualColumn> virtualColumns, bool descending, object granularity, IList<string> intervals, IFilterSpec filter, IEnumerable<IAggregationSpec> aggregations, IEnumerable<IPostAggregationSpec> postAggregations, TimeseriesContextSpec context)
    {
      DataSource = dataSource;
      VirtualColumns = virtualColumns;
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
