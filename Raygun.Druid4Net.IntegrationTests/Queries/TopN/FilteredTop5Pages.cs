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
        .Dimension(Wikiticker.Dimensions.Page)
        .Threshold(5)
        .Aggregations(new LongSumAggregator("totalCount", Wikiticker.Metrics.Count))
        .Filter(new AndFilter(
          new SelectorFilter(Wikiticker.Dimensions.IsAnonymous, "true"),
          new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US")
        ))
        .DataSource(Wikiticker.DataSource)
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
      Assert.That(_results.First().Page, Is.EqualTo("The Naked Brothers Band (TV series)"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(10));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("Total Drama Presents: The Ridonculous Race"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(4));
    }

    internal class QueryResult
    {
      public string Page { get; set; }

      public int TotalCount { get; set; }
    }
  }
}