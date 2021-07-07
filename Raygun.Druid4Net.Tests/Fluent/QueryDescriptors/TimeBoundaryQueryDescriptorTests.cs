using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TimeBoundaryQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new TimeBoundaryQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("timeBoundary"));
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .Context(
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
        ).Generate();

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
    
    [Test]
    public void DataSourceIsSet_SetsDataSourceInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .DataSource("test_datasource")
        .Generate();

      var dataSource = request.RequestData.DataSource as TableDataSource;

      Assert.IsNotNull(dataSource);
      Assert.That(dataSource.Name, Is.EqualTo("test_datasource"));
    }

    [Test]
    public void BasicFilterIsSet_SetsFilterInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .Filter(new SelectorFilter("test_dim", "test_value"))
        .Generate();

      var filter = request.RequestData.Filter as SelectorFilter;

      Assert.IsNotNull(filter);
      Assert.That(filter.Type, Is.EqualTo("selector"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dim"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }
    
    [Test]
    public void BoundIsNotSet_DoesNotSetBoundValueInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .Generate();

      Assert.That(request.RequestData.Bound, Is.Null);
    }
    
    [Test]
    public void BoundIsSetToMaxTime_SetsBoundValueInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .Bound(TimeBoundary.MaxTime)
        .Generate();

      Assert.That(request.RequestData.Bound, Is.EqualTo("maxTime"));
    }
    
    [Test]
    public void BoundIsSetToMinTime_SetsBoundValueInBody()
    {
      var request = new TimeBoundaryQueryDescriptor()
        .Bound(TimeBoundary.MinTime)
        .Generate();

      Assert.That(request.RequestData.Bound, Is.EqualTo("minTime"));
    }
  }
}