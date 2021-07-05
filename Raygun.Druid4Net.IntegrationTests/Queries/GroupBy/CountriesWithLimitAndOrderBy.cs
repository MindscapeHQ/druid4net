using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.GroupBy
{
  [TestFixture]
  public class CountriesWithLimitAndOrderBy : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.GroupBy<QueryResult>(q => q
        .Dimensions(Wikipedia.Dimensions.CountryName)
        .Aggregations(new LongSumAggregator("totalCount", Wikipedia.Metrics.Count))
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
        .Limit(new DefaultLimitSpec(10, 10, 
          new OrderByColumnSpec(Wikipedia.Dimensions.CountryName, OrderByDirection.descending))
        )
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
      Assert.That(_results.First().CountryName, Is.EqualTo("Thailand"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(8));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().CountryName, Is.EqualTo("South Africa"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(4));
    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public int TotalCount { get; set; }
    }
  }
}