using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeBoundaryQueryDescriptor : QueryDescriptor, ITimeBoundaryQueryDescriptor
  {
    internal string BoundValue;

    internal ContextSpec ContextValue;

    public TimeBoundaryQueryDescriptor()
    {
      ContextValue = new ContextSpec();
    }
    
    public ITimeBoundaryQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;
      return this;
    }

    public ITimeBoundaryQueryDescriptor Bound(TimeBoundary boundary)
    {
      switch (boundary)
      {
        case TimeBoundary.MinTime:
          BoundValue = "minTime";
          break;
        case TimeBoundary.MaxTime:
          BoundValue = "maxTime";
          break;
      }

      return this;
    }

    public ITimeBoundaryQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;
      return this;
    }
    
    public ITimeBoundaryQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);
      return this;
    }

    public IDruidRequest<TimeBoundaryRequestData> Generate()
    {
      var request = new TimeBoundaryRequest();
      request.Build(this);
      return request;
    }
  }
}
