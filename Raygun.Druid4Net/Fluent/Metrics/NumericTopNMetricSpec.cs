namespace Raygun.Druid4Net
{
  public class NumericTopNMetricSpec : ITopNMetricSpec
  {
    public string Type => "numeric";

    public string Metric { get; }

    public NumericTopNMetricSpec(string metric)
    {
      Metric = metric;
    }
  }
}