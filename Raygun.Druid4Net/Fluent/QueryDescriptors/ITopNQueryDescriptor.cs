using Raygun.Druid4Net.Fluent.Metrics;

namespace Raygun.Druid4Net
{
  public interface ITopNQueryDescriptor : IAggregatableQueryDescriptor
  {
    ITopNQueryDescriptor Dimension(string dimension);

    ITopNQueryDescriptor Metric(ITopNMetricSpec metricSpec);

    ITopNQueryDescriptor Threshold(long threshold);
  }
}