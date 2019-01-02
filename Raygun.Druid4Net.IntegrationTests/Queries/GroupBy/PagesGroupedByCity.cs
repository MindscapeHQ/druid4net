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
      var response = DruidClient.GroupBy<QueryResult>(q => q
        .Dimensions(Wikiticker.Dimensions.CountryName)
        .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Count))
        .DataSource(Wikiticker.DataSource)
        .Filter(new NotFilter(new SelectorFilter(Wikiticker.Dimensions.CountryName, string.Empty)))
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
      );

      _results = response.Data.Select(x => x.Event).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(113));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().CountryName, Is.EqualTo("Albania"));
      Assert.That(_results.First().Count, Is.EqualTo(2));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().CountryName, Is.EqualTo("Zimbabwe"));
      Assert.That(_results.Last().Count, Is.EqualTo(3));
    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public int Count { get; set; }
    }
  }
}