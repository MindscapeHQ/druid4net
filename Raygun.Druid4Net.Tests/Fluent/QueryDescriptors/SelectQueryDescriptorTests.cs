using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class SelectQueryDescriptorTests : QueryDescriptorTests<SelectQueryDescriptor, SelectRequestData>
  {
    protected override SelectQueryDescriptor CreateQueryDescriptor()
    {
      return new SelectQueryDescriptor();
    }
    
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new SelectQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("select"));
    }
    
    [Test]
    public void DimensionsAreSet_SetsDimensionsInBody()
    {
      var request = ((SelectQueryDescriptor) new SelectQueryDescriptor()
        .Dimensions("test_dim1", "test_dim2"))
        .Generate();

      Assert.That(request.RequestData.Dimensions.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Dimensions.Contains("test_dim1"), Is.True);
      Assert.That(request.RequestData.Dimensions.Contains("test_dim2"), Is.True);
    }
    
    [Test]
    public void MetricsAreSet_SetsMetricsInBody()
    {
      var request = ((SelectQueryDescriptor) new SelectQueryDescriptor()
        .Metrics("test_metric1", "test_metric2"))
        .Generate();

      Assert.That(request.RequestData.Metrics.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Metrics.Contains("test_metric1"), Is.True);
      Assert.That(request.RequestData.Metrics.Contains("test_metric2"), Is.True);
    }
    
    [Test]
    public void DescendingIsSet_SetsDescendingInBody()
    {
      var request = ((SelectQueryDescriptor) new SelectQueryDescriptor()
        .Descending(true))
        .Generate();

      Assert.That(request.RequestData.Descending, Is.True);
    }
    
    [Test]
    public void PagingIsSet_SetsDescendingInBody()
    {
      var request = ((SelectQueryDescriptor) new SelectQueryDescriptor()
        .Paging(new PagingSpec(10)))
        .Generate();

      Assert.That(request.RequestData.PagingSpec.Threshold, Is.EqualTo(10));
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = ((SelectQueryDescriptor)new SelectQueryDescriptor().Context(
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
        serializeDateTimeAsLongInner: false
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
    }
  }
}