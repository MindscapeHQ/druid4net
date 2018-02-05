using System.Runtime.Serialization;

namespace Raygun.Druid4Net.Fluent.Metrics
{
  public class NumericTopNMetricSpec : ITopNMetricSpec
  {
    [DataMember(Name = "type")]
    public string Type => "numeric";

    [DataMember(Name = "metric")]
    public string Metric;

    public NumericTopNMetricSpec(string metric)
    {
      Metric = metric;
    }
  }
}