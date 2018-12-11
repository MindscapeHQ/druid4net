using System;

namespace Raygun.Druid4Net
{
  public interface IQueryDescriptor
  {
    IQueryDescriptor DataSource(string dataSource);

    IQueryDescriptor Interval(DateTime from, DateTime to);
    
    IQueryDescriptor Intervals(params Interval[] intervals);

    IQueryDescriptor Granularity(Granularities granularity);

    IQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    IQueryDescriptor Filter(IFilterSpec filterSpec);

    //IQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);
  }
}