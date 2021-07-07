using System;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class SegmentMetadataQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new SegmentMetadataQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("segmentMetadata"));
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
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
      var request = new SegmentMetadataQueryDescriptor()
        .DataSource("test_datasource")
        .Generate();

      var dataSource = request.RequestData.DataSource as TableDataSource;

      Assert.IsNotNull(dataSource);
      Assert.That(dataSource.Name, Is.EqualTo("test_datasource"));
    }
    
    [Test]
    public void IntervalIsSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new SegmentMetadataQueryDescriptor()
        .Interval(fromDate, toDate)
        .Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
    }

    [Test]
    public void MultipleIntervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new SegmentMetadataQueryDescriptor()
        .Intervals(new Interval(fromDate, toDate), new Interval(fromDate.AddMonths(1), toDate.AddMonths(1)))
        .Generate();

      Assert.That(request.RequestData.Intervals.Count, Is.EqualTo(2));
      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
      Assert.That(request.RequestData.Intervals[1], Is.EqualTo("2017-11-01T14:45:22.123Z/2017-11-02T10:35:21.345Z"));
    }

    [Test]
    public void ToIntervalIsBeforeFromInterval_ToIntervalEqualsFromInterval()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = fromDate.AddHours(-1);
      var request = new SegmentMetadataQueryDescriptor()
        .Interval(fromDate, toDate)
        .Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-01T14:45:22.123Z"));
    }
    
    [Test]
    public void ToIncludeIsSet_SetsToIncludeAllInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .ToInclude(new ToIncludeAllSpec())
        .Generate();

      Assert.That(request.RequestData.ToInclude.Type, Is.EqualTo("all"));
    }
    
    [Test]
    public void ToIncludeIsSet_SetsToIncludeNoneInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .ToInclude(new ToIncludeNoneSpec())
        .Generate();

      Assert.That(request.RequestData.ToInclude.Type, Is.EqualTo("none"));
    }
    
    [Test]
    public void ToIncludeIsSet_SetsToIncludeListInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .ToInclude(new ToIncludeListSpec("colA", "colB"))
        .Generate();

      Assert.That(request.RequestData.ToInclude.Type, Is.EqualTo("list"));
      Assert.That(request.RequestData.ToInclude, Is.InstanceOf(typeof(ToIncludeListSpec)));
      var listSpec = (ToIncludeListSpec) request.RequestData.ToInclude; 
      Assert.That(listSpec.Columns.Count(), Is.EqualTo(2));
      Assert.That(listSpec.Columns.First(), Is.EqualTo("colA"));
    }
    
    [Test]
    public void MergeIsSet_SetsMergeInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .Merge(true)
        .Generate();

      Assert.That(request.RequestData.Merge, Is.EqualTo(true));
    }
    
    [Test]
    public void AnalysisTypesIsSet_SetsAnalysisTypesInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .AnalysisTypes(AnalysisType.aggregators, AnalysisType.cardinality)
        .Generate();

      Assert.That(request.RequestData.AnalysisTypes.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.AnalysisTypes.First(), Is.EqualTo(AnalysisType.aggregators));
    }

    [Test]
    public void LenientAggregatorMergeIsSet_SetsLenientAggregatorMergeInBody()
    {
      var request = new SegmentMetadataQueryDescriptor()
        .LenientAggregatorMerge(true)
        .Generate();

      Assert.That(request.RequestData.LenientAggregatorMerge, Is.EqualTo(true));
    }
  }
}
