using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IQueryDescriptor
  {
    IQueryDescriptor DataSource(string dataSource);

    IQueryDescriptor Interval(DateTime from, DateTime to);
    
    IQueryDescriptor Intervals(params Interval[] intervals);
    
    IQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    IQueryDescriptor Granularity(Granularities granularity);

    IQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    IQueryDescriptor Filter(IFilterSpec filterSpec);
  }
}