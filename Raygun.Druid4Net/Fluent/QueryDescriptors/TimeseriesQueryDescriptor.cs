namespace Raygun.Druid4Net
{
  public class TimeseriesQueryDescriptor : AggregatableQueryDescriptor<TimeseriesRequestData>, ITimeseriesQueryDescriptor
  {
    internal bool DescendingValue;

    internal TimeseriesContextSpec ContextValue;

    public TimeseriesQueryDescriptor()
    {
      ContextValue = new TimeseriesContextSpec();
    }

    public ITimeseriesQueryDescriptor Descending(bool descending)
    {
      DescendingValue = descending;

      return this;
    }

    public ITimeseriesQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, bool? skipEmptyBuckets = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.SkipEmptyBuckets = skipEmptyBuckets;

      return this;
    }

    internal override IDruidRequest<TimeseriesRequestData> Generate()
    {
      var request = new TimeseriesRequest();
      request.Build(this);

      return request;
    }
  }
}
