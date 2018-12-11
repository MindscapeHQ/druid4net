namespace Raygun.Druid4Net
{
  public class InvertedTopNMetricSpec : ITopNMetricSpec
  {
    public string Type => "inverted";

    public ITopNMetricSpec Metric;

    public InvertedTopNMetricSpec(ITopNMetricSpec metric)
    {
      Metric = metric;
    }
  }
}