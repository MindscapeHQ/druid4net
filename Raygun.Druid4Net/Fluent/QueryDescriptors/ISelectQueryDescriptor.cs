using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ISelectQueryDescriptor : IQueryDescriptor
  {
    ISelectQueryDescriptor Metrics(params string[] metrics);

    ISelectQueryDescriptor Dimensions(params string[] dimensions);

    ISelectQueryDescriptor Paging(PagingSpec pagingSpec);

    ISelectQueryDescriptor Descending(bool descending);
    
    IQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);
  }
}