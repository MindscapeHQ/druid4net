using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Timeseries
{
  [TestFixture]
  public class PagesAddedOverTimeByHour : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Timeseries<TimeseriesResult<QueryResult>>(q => q
        .Descending(true)
        .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Added))
        .Filter(new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US"))
        .DataSource(Wikiticker.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.Hour)
      );

      _results = response.Data.Select(x => x.Result).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(10));
    }

//    [Test]
//    public void FirstResultIsCorrect()
//    {
//      Assert.That(_results.First().Page, Is.EqualTo("Wikipedia:Vandalismusmeldung"));
//      Assert.That(_results.First().Count, Is.EqualTo(33));
//    }
//
//    [Test]
//    public void LastResultIsCorrect()
//    {
//      Assert.That(_results.Last().Page, Is.EqualTo("Wikipedia:Requests for page protection"));
//      Assert.That(_results.Last().Count, Is.EqualTo(17));
//    }

    private class QueryResult
    {
      public int Added { get; set; }
    }
  }
}