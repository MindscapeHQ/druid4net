using Raygun.Druid4Net.Fluent.Metrics;

namespace Raygun.Druid4Net
{
  public class TopNQueryDescriptor : AggregatableQueryDescriptor, ITopNQueryDescriptor
  {
    public string QueryType => "topN";

    internal string DimensionValue;

    internal ITopNMetricSpec MetricSpecValue;

    internal long ThresholdValue;

    public ITopNQueryDescriptor Dimension(string dimension)
    {
      DimensionValue = dimension;

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

    internal override IDruidRequest Generate()
    {
      var request = new TopNRequest();
      request.Build(this);

      return request;
    }
  }
}
