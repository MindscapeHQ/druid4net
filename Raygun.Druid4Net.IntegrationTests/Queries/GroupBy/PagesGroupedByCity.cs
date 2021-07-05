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
        .Dimensions(Wikipedia.Dimensions.CountryName)
        .Aggregations(new LongSumAggregator("totalCount", Wikipedia.Metrics.Count))
        .DataSource(Wikipedia.DataSource)
        .Filter(new NotFilter(new SelectorFilter(Wikipedia.Dimensions.CountryName, string.Empty)))
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
      );

      _results = response.Data.Select(x => x.Event).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(105));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().CountryName, Is.EqualTo("Albania"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(1));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().CountryName, Is.EqualTo("Vietnam"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(18));
    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public int TotalCount { get; set; }
    }
  }
}