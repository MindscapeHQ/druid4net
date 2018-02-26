using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TopN
{
  [TestFixture]
  public class Top10Pages : TestQueryBase
  {
    private IList<Top10Page> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.TopN<TopNResult<Top10Page>>(q => q
        .Metric("pageCount")
        .Dimension("uri")
        .Threshold(10)
        .Aggregations(new LongSumAggregator("pageCount", "count"))
        .DataSource(TestDataSource)
        .Intervals(FromDate, ToDate)
        .Filter(new SelectorFilter("type", "p"))
        .Granularity(Granularities.All)
      );

      _results = response.Data.SelectMany(x => x.Result).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(5));
    }
  }

  public class Top10Page
  {
    public string Uri { get; set; }

    public int PageCount { get; set; }
  }
}