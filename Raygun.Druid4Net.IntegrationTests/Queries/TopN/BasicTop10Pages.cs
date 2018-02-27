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
      var response = DruidClient.TopN<TopNResult<QueryResult>>(q => q
        .Metric(Wikiticker.Metrics.Count)
        .Dimension(Wikiticker.Dimensions.Page)
        .Threshold(10)
        .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Count))
        .DataSource(Wikiticker.DataSource)
        .Intervals(FromDate, ToDate)
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
      Assert.That(_results.First().Page, Is.EqualTo("Wikipedia:Vandalismusmeldung"));
      Assert.That(_results.First().Count, Is.EqualTo(33));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("Wikipedia:Requests for page protection"));
      Assert.That(_results.Last().Count, Is.EqualTo(17));
    }

    internal class QueryResult
    {
      public string Page { get; set; }

      public int Count { get; set; }
    }
  }
}