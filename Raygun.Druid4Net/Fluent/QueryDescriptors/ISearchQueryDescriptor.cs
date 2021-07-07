using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ISearchQueryDescriptor
  {
    ISearchQueryDescriptor DataSource(string dataSource);
    
    ISearchQueryDescriptor DataSource(IDataSourceSpec dataSource);
    
    ISearchQueryDescriptor Interval(DateTime from, DateTime to);
    
    ISearchQueryDescriptor Intervals(params Interval[] intervals);
    
    ISearchQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    ISearchQueryDescriptor Granularity(Granularities granularity);

    ISearchQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    ISearchQueryDescriptor Filter(IFilterSpec filterSpec);
    
    ISearchQueryDescriptor Limit(int limit);

    ISearchQueryDescriptor SearchDimensions(params string[] dimensions);
    
    ISearchQueryDescriptor SearchDimensions(IEnumerable<string> dimensions);
    
    ISearchQueryDescriptor Query(ISearchQuerySpec querySpec);
    
    ISearchQueryDescriptor Sort(SortingOrder sort);
    
    ISearchQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, SearchStrategy? searchStrategy = null);

    IDruidRequest<SearchRequestData> Generate();
  }
}
