using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TopN
{
  [TestFixture]
  public class BasicTop10Pages : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.TopN<QueryResult>(q => q
        .Dimension(Wikipedia.Dimensions.Page)
        .Threshold(10)
        .Aggregations(new LongSumAggregator("totalCount", Wikipedia.Metrics.Count))
        .Metric("totalCount")
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Granularity(Granularities.All)
      );

      _results = response.Data.SelectMany(x => x.Result).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(10));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Page, Is.EqualTo("Copa América Centenario"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(29));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("Lionel Messi"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(10));
    }

    internal class QueryResult
    {
      public string Page { get; set; }

      public int TotalCount { get; set; }
    }
  }
}