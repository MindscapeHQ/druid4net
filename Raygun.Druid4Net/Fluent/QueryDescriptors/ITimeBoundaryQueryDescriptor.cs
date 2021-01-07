using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ITimeBoundaryQueryDescriptor
  {
    ITimeBoundaryQueryDescriptor DataSource(string dataSource);
    
    ITimeBoundaryQueryDescriptor Bound(TimeBoundary boundary);
    
    ITimeBoundaryQueryDescriptor Filter(IFilterSpec filterSpec);
    
    ITimeBoundaryQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);

    IDruidRequest<TimeBoundaryRequestData> Generate();
  }
}
