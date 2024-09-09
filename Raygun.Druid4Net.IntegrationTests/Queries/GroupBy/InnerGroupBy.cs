using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.GroupBy;

[TestFixture]
public class InnerGroupBy : TestQueryBase
{
  private IList<QueryResult> _results;

  [SetUp]
  public async Task Execute()
  {
    var response = await DruidClient.GroupByAsync<QueryResult>(q => q
      .DataSource(inner => inner
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Dimensions(Wikipedia.Dimensions.CountryName)
        .Filter(new NotFilter(new SelectorFilter(Wikipedia.Dimensions.CountryName, string.Empty)))
      )
      .Interval(FromDate, ToDate)
      .Granularity(Granularities.All)
      .Aggregations(new CountAggregator("totalCount"))
    );

    _results = response.Data.Select(x => x.Event).ToList();
  }

  [Test]
  public void QueryHasCorrectNumberOfResults()
  {
    Assert.That(_results.Count, Is.EqualTo(1));
  }

  [Test]
  public void FirstResultIsCorrect()
  {
    Assert.That(_results.First().TotalCount, Is.EqualTo(105));
  }

  private class QueryResult
  {
    public long TotalCount { get; set; }
  }
}