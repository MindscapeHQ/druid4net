using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.GroupBy
{
  [TestFixture]
  public class PagesGroupedByCity : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.GroupBy<GroupByResult<QueryResult>>(q => q
        .Dimensions(Wikiticker.Dimensions.CountryName, Wikiticker.Dimensions.CityName, Wikiticker.Dimensions.Page)
        .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Count))
        .DataSource(Wikiticker.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
      );

      _results = response.Data.Select(x => x.Event).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(10));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Page, Is.EqualTo("Wikipedia:Vandalismusmeldung"));
      Assert.That(_results.First().Count, Is.EqualTo(33));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("Wikipedia:Requests for page protection"));
      Assert.That(_results.Last().Count, Is.EqualTo(17));
    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public string CityName { get; set; }
      public string Page { get; set; }
      public int Count { get; set; }
    }
  }
}