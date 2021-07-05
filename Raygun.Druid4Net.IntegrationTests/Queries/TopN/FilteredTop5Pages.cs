using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TopN
{
  [TestFixture]
  public class FilteredTop5Pages : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.TopN<QueryResult>(q => q
        .Metric("totalCount")
        .Dimension(Wikipedia.Dimensions.Page)
        .Threshold(5)
        .Aggregations(new LongSumAggregator("totalCount", Wikipedia.Metrics.Count))
        .Filter(new AndFilter(
          new SelectorFilter(Wikipedia.Dimensions.IsAnonymous, "true"),
          new SelectorFilter(Wikipedia.Dimensions.CountryCode, "US")
        ))
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
      );

      _results = response.Data.SelectMany(x => x.Result).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(5));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Page, Is.EqualTo("2016 Wimbledon Championships – Men's Singles"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(11));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("1995 NHL Entry Draft"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(2));
    }

    internal class QueryResult
    {
      public string Page { get; set; }

      public int TotalCount { get; set; }
    }
  }
}