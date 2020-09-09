using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class ScanQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new ScanQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("scan"));
    }
    
    [Test]
    public void DataSourceIsSet_SetsDataSourceInBody()
    {
      var request = new ScanQueryDescriptor()
        .DataSource("test_datasource")
        .Generate();

      Assert.That(request.RequestData.DataSource, Is.EqualTo("test_datasource"));
    }
    
    [Test]
    public void ColumnsAreSetAsParameters_SetsColumnsInBody()
    {
      var request = new ScanQueryDescriptor()
        .Columns("test_dim1", "test_dim2")
        .Generate();

      Assert.That(request.RequestData.Columns.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Columns, Contains.Item("test_dim1"));
      Assert.That(request.RequestData.Columns, Contains.Item("test_dim2"));
    }
    
    [Test]
    public void ColumnsAreSetAsEnumerable_SetsColumnsInBody()
    {
      var dimensions = new List<string> {"test_dim1", "test_dim2"};
      var request = new ScanQueryDescriptor()
        .Columns(dimensions)
        .Generate();

      Assert.That(request.RequestData.Columns.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Columns, Contains.Item("test_dim1"));
      Assert.That(request.RequestData.Columns, Contains.Item("test_dim2"));
    }
    
    [Test]
    public void LimitIsSet_SetsLimitInBody()
    {
      var request = new ScanQueryDescriptor()
        .Limit(500)
        .Generate();

      Assert.That(request.RequestData.Limit, Is.EqualTo(500));
    }

    [Test]
    public void OrderIsSet_SetsLimitInBody()
    {
        var request = new ScanQueryDescriptor()
            .Order(OrderByDirection.descending)
            .Generate();

        Assert.That(request.RequestData.Order, Is.EqualTo(OrderByDirection.descending));
    }

        [Test]
    public void BatchSizeIsSet_SetsBatchSizeInBody()
    {
      var request = new ScanQueryDescriptor()
        .BatchSize(200)
        .Generate();

      Assert.That(request.RequestData.BatchSize, Is.EqualTo(200));
    }
    
    [TestCase(ScanResultFormat.List, "list")]
    [TestCase(ScanResultFormat.CompactedList, "compactedList")]
    public void ResultFormatIsSet_SetsResultFormatInBody(ScanResultFormat resultFormat, string expectedResult)
    {
      var request = new ScanQueryDescriptor()
        .ResultFormat(resultFormat)
        .Generate();

      Assert.That(request.RequestData.ResultFormat, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = new ScanQueryDescriptor()
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
    public void InvervalIsSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new ScanQueryDescriptor()
        .Interval(fromDate, toDate)
        .Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
    }

    [Test]
    public void MultipleInvervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new ScanQueryDescriptor()
        .Intervals(new Interval(fromDate, toDate), new Interval(fromDate.AddMonths(1), toDate.AddMonths(1)))
        .Generate();

      Assert.That(request.RequestData.Intervals.Count, Is.EqualTo(2));
      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
      Assert.That(request.RequestData.Intervals[1], Is.EqualTo("2017-11-01T14:45:22.123Z/2017-11-02T10:35:21.345Z"));
    }

    [Test]
    public void IntervalsAreSetByEnumerable_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new ScanQueryDescriptor()
        .Intervals(new List<Interval> { new Interval(fromDate, toDate)})
        .Generate();

      Assert.That(request.RequestData.Intervals.Count, Is.EqualTo(1));
      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
    }

    [Test]
    public void BasicFilterIsSet_SetsFilterInBody()
    {
      var request = new ScanQueryDescriptor()
        .Filter(new SelectorFilter("test_dim", "test_value"))
        .Generate();

      var filter = request.RequestData.Filter as SelectorFilter;

      Assert.IsNotNull(filter);
      Assert.That(filter.Type, Is.EqualTo("selector"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dim"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }
  }
}