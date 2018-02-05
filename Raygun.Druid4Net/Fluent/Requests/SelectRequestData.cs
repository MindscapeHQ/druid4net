﻿using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SelectRequestData
  {
    public string QueryType { get; }
    public string DataSource { get; }
    public object Granularity { get; }
    public List<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public ContextSpec Context { get; }
    public IEnumerable<string> Dimensions { get; }
    public IEnumerable<string> Metrics { get; }
    public PagingSpec PagingSpec { get; }
    public bool Descending { get; }

    public SelectRequestData(string queryType, string dataSource, object granularity, List<string> intervals, IFilterSpec filter, ContextSpec context, IEnumerable<string> dimensions, IEnumerable<string> metrics, PagingSpec pagingSpec, bool descending)
    {
      QueryType = queryType;
      DataSource = dataSource;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Dimensions = dimensions;
      Metrics = metrics;
      PagingSpec = pagingSpec;
      Descending = descending;
    }
  }
}