using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TopN
{
  [TestFixture]
  public class AsyncBasicTop10Pages : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public async Task Execute()
    {
      var response = await DruidClient.TopNAsync<QueryResult>(q => q
        .Metric("totalCount")
        .Dimension(Wikiticker.Dimensions.Page)
        .Threshold(10)
        .Aggregations(new LongSumAggregator("totalCount", Wikiticker.Metrics.Count))
        .DataSource(Wikiticker.DataSource)
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
      Assert.That(_results.First().Page, Is.EqualTo("Wikipedia:Vandalismusmeldung"));
      Assert.That(_results.First().TotalCount, Is.EqualTo(33));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Page, Is.EqualTo("Wikipedia:Requests for page protection"));
      Assert.That(_results.Last().TotalCount, Is.EqualTo(17));
    }

    internal class QueryResult
    {
      public string Page { get; set; }

      public int TotalCount { get; set; }
    }
  }
}