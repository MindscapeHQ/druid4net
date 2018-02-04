namespace Raygun.Druid4Net
{
  public interface ITopNQueryDescriptor
  {
    ITopNQueryDescriptor Dimension(string dimension);

    ITopNQueryDescriptor Metric(TopNMetricSpec metricSpec);

    ITopNQueryDescriptor Threshold(long threshold);
  }
}