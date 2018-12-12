using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TopNQueryDescriptorTests : AggregationQueryDescriptorTests<TopNQueryDescriptor, TopNRequestData>
  {
    protected override TopNQueryDescriptor CreateQueryDescriptor()
    {
      return new TopNQueryDescriptor();
    }
    
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
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Context(
        timeout: 60, 
        maxScatterGatherBytes: 100,
        priority: 10,
        queryId: "ABC",
        useCache: false,
        populateCache: false,
        bySegment: true,
        finalize: false,
        chunkPeriod: "PT1H",
        serializeDateTimeAsLong: true,
        serializeDateTimeAsLongInner: false,
        minTopNThreshold: 500
        )).Generate();

      var context = request.RequestData.Context;

      Assert.IsNotNull(context);
      Assert.That(context.Timeout, Is.EqualTo(60));
      Assert.That(context.MaxScatterGatherBytes, Is.EqualTo(100));
      Assert.That(context.Priority, Is.EqualTo(10));
      Assert.That(context.QueryId, Is.EqualTo("ABC"));
      Assert.That(context.UseCache, Is.False);
      Assert.That(context.PopulateCache, Is.False);
      Assert.That(context.BySegment, Is.True);
      Assert.That(context.Finalize, Is.False);
      Assert.That(context.ChunkPeriod, Is.EqualTo("PT1H"));
      Assert.That(context.SerializeDateTimeAsLong, Is.True);
      Assert.That(context.SerializeDateTimeAsLongInner, Is.False);
      Assert.That(context.MinTopNThreshold, Is.EqualTo(500));
    }
  }
}