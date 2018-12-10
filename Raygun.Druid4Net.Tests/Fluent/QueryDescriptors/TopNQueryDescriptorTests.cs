using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TopNQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new TopNQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("topN"));
    }
    
    [Test]
    public void DimensionIsSet_SetsDimensionInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor()
        .Dimension("test_dim"))
        .Generate();

      Assert.That(request.RequestData.Dimension, Is.EqualTo("test_dim"));
    }

    [Test]
    public void MetricSpecIsSet_SetsMetricInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor()
        .Metric(new NumericTopNMetricSpec("test_metric")))
        .Generate();

      var metric = request.RequestData.Metric as NumericTopNMetricSpec;

      Assert.IsNotNull(metric);
      Assert.That(metric.Type, Is.EqualTo("numeric"));
      Assert.That(metric.Metric, Is.EqualTo("test_metric"));
    }

    [Test]
    public void MetricIsSet_SetsMetricInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor()
        .Metric("test_metric"))
        .Generate();

      var metric = request.RequestData.Metric as NumericTopNMetricSpec;

      Assert.IsNotNull(metric);
      Assert.That(metric.Type, Is.EqualTo("numeric"));
      Assert.That(metric.Metric, Is.EqualTo("test_metric"));
    }

    [Test]
    public void ThresholdIsSet_SetsThresholdInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor()
        .Threshold(10))
        .Generate();

      Assert.That(request.RequestData.Threshold, Is.EqualTo(10));
    }

    [Test]
    public void ContextMinTopNThresholdIsSet_SetsMinTopNThresholdInBody()
    {
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor()
        .Context(minTopNThreshold: 500))
        .Generate();

      Assert.That(request.RequestData.Context.MinTopNThreshold, Is.EqualTo(500));
    }
  }
}