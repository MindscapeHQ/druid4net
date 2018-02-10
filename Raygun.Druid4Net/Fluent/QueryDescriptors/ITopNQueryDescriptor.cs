namespace Raygun.Druid4Net
{
  public interface ITopNQueryDescriptor : IAggregatableQueryDescriptor
  {
    ITopNQueryDescriptor Dimension(string dimension);

    ITopNQueryDescriptor Metric(ITopNMetricSpec metricSpec);

    ITopNQueryDescriptor Threshold(long threshold);

    ITopNQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, int? minTopNThreshold = null);
  }
}