using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Timeseries
{
  [TestFixture]
  public class PagesAddedOverTimeByHour : TestQueryBase
  {
    private TimeseriesResult<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Timeseries<QueryResult>(q => q
        .Descending(true)
        .Aggregations(new LongSumAggregator("totalAdded", Wikiticker.Metrics.Added))
        .Filter(new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US"))
        .DataSource(Wikiticker.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.Hour)
      );

      _results = response.Data;
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(24));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Timestamp, Is.EqualTo(new DateTime(2015, 9, 12, 23, 0, 0,DateTimeKind.Utc)));
      Assert.That(_results.First().Result.TotalAdded, Is.EqualTo(3913));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Timestamp, Is.EqualTo(new DateTime(2015, 9, 12, 0, 0, 0,DateTimeKind.Utc)));
      Assert.That(_results.Last().Result.TotalAdded, Is.EqualTo(88));
    }

    private class QueryResult
    {
      public int TotalAdded { get; set; }
    }
  }
}