namespace Raygun.Druid4Net
{
  public class TopNQueryDescriptor : AggregatableQueryDescriptor<TopNRequestData>, ITopNQueryDescriptor
  {
    internal string DimensionValue;

    internal ITopNMetricSpec MetricSpecValue;

    internal long ThresholdValue;

    internal new TopNContextSpec ContextValue;

    public TopNQueryDescriptor()
    {
      ContextValue = new TopNContextSpec();
    }

    public ITopNQueryDescriptor Dimension(string dimension)
    {
      DimensionValue = dimension;

      return this;
    }

    public ITopNQueryDescriptor Metric(string metric)
    {
      MetricSpecValue = new NumericTopNMetricSpec(metric);

      return this;
    }

    public ITopNQueryDescriptor Metric(ITopNMetricSpec metricSpec)
    {
      MetricSpecValue = metricSpec;

      return this;
    }

    public ITopNQueryDescriptor Threshold(long threshold)
    {
      ThresholdValue = threshold;

      return this;
    }

    public ITopNQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, int? minTopNThreshold = null)
    {
      SetCommonContextProperties(timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.MinTopNThreshold = minTopNThreshold;

      return this;
    }

    internal override IDruidRequest<TopNRequestData> Generate()
    {
      var request = new TopNRequest();
      request.Build(this);

      return request;
    }
  }
}
