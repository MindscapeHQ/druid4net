using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ISelectQueryDescriptor
  {
    ISelectQueryDescriptor DataSource(string dataSource);

    ISelectQueryDescriptor Interval(DateTime from, DateTime to);
    
    ISelectQueryDescriptor Intervals(params Interval[] intervals);
    
    ISelectQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    ISelectQueryDescriptor Granularity(Granularities granularity);

    ISelectQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    ISelectQueryDescriptor Filter(IFilterSpec filterSpec);
    
    ISelectQueryDescriptor Metrics(params string[] metrics);
    
    ISelectQueryDescriptor Metrics(IEnumerable<string> metrics);

    ISelectQueryDescriptor Dimensions(params string[] dimensions);
    
    ISelectQueryDescriptor Dimensions(IEnumerable<string> dimensions);

    ISelectQueryDescriptor Paging(PagingSpec pagingSpec);

    ISelectQueryDescriptor Descending(bool descending);
    
    ISelectQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);

    IDruidRequest<SelectRequestData> Generate();
  }
}