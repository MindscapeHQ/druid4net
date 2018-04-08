using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class QueryDescriptorTests
  {
    [Test]
    public void DatasourceIsSet_SetsDatasourceInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().DataSource("test_datasource")).Generate();

      Assert.That(request.RequestData.DataSource, Is.EqualTo("test_datasource"));
    }

    [Test]
    public void InvervalIsSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Interval(fromDate, toDate)).Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22Z/2017-10-02T10:35:21Z"));
    }

    [Test]
    public void MultipleInvervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Intervals(new Interval(fromDate, toDate), new Interval(fromDate.AddMonths(1), toDate.AddMonths(1)))).Generate();

      Assert.That(request.RequestData.Intervals.Count, Is.EqualTo(2));
      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22Z/2017-10-02T10:35:21Z"));
      Assert.That(request.RequestData.Intervals[1], Is.EqualTo("2017-11-01T14:45:22Z/2017-11-02T10:35:21Z"));
    }

    [Test]
    public void ToIntervalIsBeforeFromInterval_ToIntervalEqualsFromInterval()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = fromDate.AddHours(-1);
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Interval(fromDate, toDate)).Generate();

      Assert.That(request.RequestData.Intervals[0], Is.EqualTo("2017-10-01T14:45:22Z/2017-10-01T14:45:22Z"));
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
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Granularity(granularity)).Generate();
 
      Assert.That(request.RequestData.Granularity, Is.EqualTo(expectedGranularity));
    }
    
    [Test]
    public void DurationGranularitySpecIsSet_SetsGranularityInBody()
    {
      var originDate = DateTime.Parse("2017-10-01T14:45:22");
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Granularity(new DurationGranularity(60, originDate))).Generate();
 
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
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Granularity(new PeriodGranularity("PT10M", "UTC", originDate))).Generate();
 
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
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Filter(new SelectorFilter("test_dim", "test_value"))).Generate();

      var filter = request.RequestData.Filter as SelectorFilter;

      Assert.IsNotNull(filter);
      Assert.That(filter.Type, Is.EqualTo("selector"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dim"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }
    
    [Test]
    public void CommonContextPropertiesAreSet_SetsContextInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Context(
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
        serializeDateTimeAsLongInner: false)).Generate();

      var context = request.RequestData.Context as ContextSpec;

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