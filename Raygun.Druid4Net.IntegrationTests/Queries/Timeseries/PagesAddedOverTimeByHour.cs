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
        .Aggregations(new LongSumAggregator("totalAdded", Wikipedia.Metrics.Added))
        .Filter(new SelectorFilter(Wikipedia.Dimensions.CountryCode, "US"))
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.Hour)
      );

      _results = response.Data;
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(22));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Timestamp, Is.EqualTo(new DateTime(2016, 6, 27, 21, 0, 0,DateTimeKind.Utc)));
      Assert.That(_results.First().Result.TotalAdded, Is.EqualTo(1260));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Timestamp, Is.EqualTo(new DateTime(2016, 6, 27, 0, 0, 0,DateTimeKind.Utc)));
      Assert.That(_results.Last().Result.TotalAdded, Is.EqualTo(1423));
    }

    private class QueryResult
    {
      public int TotalAdded { get; set; }
    }
  }
}