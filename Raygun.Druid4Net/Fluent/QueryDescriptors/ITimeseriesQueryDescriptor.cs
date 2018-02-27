namespace Raygun.Druid4Net
{
  public interface ITimeseriesQueryDescriptor : IAggregatableQueryDescriptor
  {
    ITimeseriesQueryDescriptor Descending(bool descending);

    ITimeseriesQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, bool? skipEmptyBuckets = null);

  }
}