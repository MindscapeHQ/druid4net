using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TimeseriesQueryDescriptorTests : AggregationQueryDescriptorTests<TimeseriesQueryDescriptor, TimeseriesRequestData>
  {
    protected override TimeseriesQueryDescriptor CreateQueryDescriptor()
    {
      return new TimeseriesQueryDescriptor();
    }
    
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new TimeseriesQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("timeseries"));
    }
    
    [Test]
    public void DescendingIsSet_SetsDescendingInBody()
    {
      var request = ((TimeseriesQueryDescriptor) new TimeseriesQueryDescriptor()
        .Descending(true))
        .Generate();

      Assert.That(request.RequestData.Descending, Is.True);
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = ((TimeseriesQueryDescriptor)new TimeseriesQueryDescriptor().Context(
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
        skipEmptyBuckets: true
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
      Assert.That(context.SkipEmptyBuckets, Is.True);
    }
  }
}