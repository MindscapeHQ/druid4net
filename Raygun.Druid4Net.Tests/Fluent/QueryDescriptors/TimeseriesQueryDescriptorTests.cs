using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TimeseriesQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new TimeseriesQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("timeseries"));
    }
    
    [Test]
    public void DescendingIsSet_SetsDescendingInBody()
    {
      var request = new TimeseriesQueryDescriptor()
        .Descending(true)
        .Generate();

      Assert.That(request.RequestData.Descending, Is.True);
    }
    
    [Test]
    public void ContextPropertiesAreSet_SetsContextInBody()
    {
      var request = new TimeseriesQueryDescriptor()
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
          serializeDateTimeAsLongInner: false,
          skipEmptyBuckets: true
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
      Assert.That(context.SkipEmptyBuckets, Is.True);
    }
    
    [Test]
    public void DataSourceIsSet_SetsDataSourceInBody()
    {
      var request = new TimeseriesQueryDescriptor()
        .DataSource("test_datasource")
        .Generate();

      Assert.That(request.RequestData.DataSource, Is.EqualTo("test_datasource"));
    }

    [Test]
    public void InvervalIsSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new TimeseriesQueryDescriptor()
        .Interval(fromDate, toDate)
        .Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-02T10:35:21.345Z"));
    }

    [Test]
    public void MultipleInvervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = new TimeseriesQueryDescriptor()
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
      var request = new TimeseriesQueryDescriptor()
        .Interval(fromDate, toDate)
        .Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22.123Z/2017-10-01T14:45:22.123Z"));
    }

    [Test]
    [TestCase(Granularities.All, "all")]
    [TestCase(Granularities.None, "none")]
    [TestCase(Granularities.Second, "second")]
    [TestCase(Granularities.Minute, "minute")]
    [TestCase(Granularities.FifteenMinute, "fifteen_minute")]
    [TestCase(Granularities.ThirtyMinute, "thirty_minute")]
    [TestCase(Granularities.Hour, "hour")]
    [TestCase(Granularities.Day, "day")]
    [TestCase(Granularities.Week, "week")]
    [TestCase(Granularities.Month, "month")]
    [TestCase(Granularities.Quarter, "quarter")]
    [TestCase(Granularities.Year, "year")]
    public void GranularityIsSet_SetsGranularityInBody(Granularities granularity, string expectedGranularity)
    {
      var request = new TimeseriesQueryDescriptor()
        .Granularity(granularity)
        .Generate();
 
      Assert.That(request.RequestData.Granularity, Is.EqualTo(expectedGranularity));
    }
    
    [Test]
    public void DurationGranularitySpecIsSet_SetsGranularityInBody()
    {
      var originDate = DateTime.Parse("2017-10-01T14:45:22");
      var request = new TimeseriesQueryDescriptor()
        .Granularity(new DurationGranularity(60, originDate))
        .Generate();
 
      var granularity = request.RequestData.Granularity as DurationGranularity;

      Assert.IsNotNull(granularity);
      Assert.That(granularity.Type, Is.EqualTo("duration"));
      Assert.That(granularity.Duration, Is.EqualTo(60));
      Assert.That(granularity.Origin, Is.EqualTo(originDate));
    }
    
    [Test]
    public void PeriodGranularitySpecIsSet_SetsGranularityInBody()
    {
      var originDate = DateTime.Parse("2017-10-01T14:45:22");
      var request = new TimeseriesQueryDescriptor()
        .Granularity(new PeriodGranularity("PT10M", "UTC", originDate))
        .Generate();
 
      var granularity = request.RequestData.Granularity as PeriodGranularity;

      Assert.IsNotNull(granularity);
      Assert.That(granularity.Type, Is.EqualTo("period"));
      Assert.That(granularity.Period, Is.EqualTo("PT10M"));
      Assert.That(granularity.TimeZone, Is.EqualTo("UTC"));
      Assert.That(granularity.Origin, Is.EqualTo(originDate));
    }

    [Test]
    public void BasicFilterIsSet_SetsFilterInBody()
    {
      var request = new TimeseriesQueryDescriptor()
        .Filter(new SelectorFilter("test_dim", "test_value"))
        .Generate();

      var filter = request.RequestData.Filter as SelectorFilter;

      Assert.IsNotNull(filter);
      Assert.That(filter.Type, Is.EqualTo("selector"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dim"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }
    
    [Test]
    public void SumAggregationIsSet_SetsAggregationInBody()
    {
      var request = new TimeseriesQueryDescriptor()
        .Aggregations(new LongSumAggregator("sum_count", "count"))
        .Generate();

      var agg = request.RequestData.Aggregations.First() as LongSumAggregator;

      Assert.IsNotNull(agg);
      Assert.That(agg.Type, Is.EqualTo("longSum"));
      Assert.That(agg.Name, Is.EqualTo("sum_count"));
      Assert.That(agg.FieldName, Is.EqualTo("count"));
    }

    [Test]
    public void ArithmeticPostAggregataionIsSet_SetsPostAggregationInBody()
    {
      var fields = new List<IPostAggregationSpec> {new FieldAccessPostAggregator("loaded", "my_loaded"), new FieldAccessPostAggregator("total", "my_total") };
      var aggregations = new List<IPostAggregationSpec> {new ArithmeticPostAggregator("average", ArithmeticFunction.Divide, fields) };
      var request = new TimeseriesQueryDescriptor()
        .PostAggregations(aggregations)
        .Generate();

      var agg = request.RequestData.PostAggregations.First() as ArithmeticPostAggregator;

      Assert.IsNotNull(agg);
      Assert.That(agg.Type, Is.EqualTo("arithmetic"));
      Assert.That(agg.Name, Is.EqualTo("average"));
      Assert.That(agg.Fn, Is.EqualTo("/"));

      var field1 = agg.Fields.First() as FieldAccessPostAggregator;

      Assert.IsNotNull(field1);
      Assert.That(field1.Type, Is.EqualTo("fieldAccess"));
      Assert.That(field1.Name, Is.EqualTo("loaded"));
      Assert.That(field1.FieldName, Is.EqualTo("my_loaded"));

      var field2 = agg.Fields.Last() as FieldAccessPostAggregator;
      Assert.IsNotNull(field2);
      Assert.That(field2.Type, Is.EqualTo("fieldAccess"));
      Assert.That(field2.Name, Is.EqualTo("total"));
      Assert.That(field2.FieldName, Is.EqualTo("my_total"));
    }
  }
}