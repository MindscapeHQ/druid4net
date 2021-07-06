using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Scan
{
  [TestFixture]
  public class BoundFilterOnMetric : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Scan<QueryResult>(q => q
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Filter(new BoundFilter<int?>(Wikipedia.Metrics.Added, 10_000, null, lowerStrict: true, ordering: SortingOrder.numeric))
        .Columns(Wikipedia.Metrics.Added)
      );

      _results = response.Data.SelectMany(x => x.Events).ToList();
    }

    [Test]
    public void AllResultsHaveAddedGreaterThanTenThousand()
    {
      foreach (var result in _results)
      {
        Assert.That(result.Added, Is.GreaterThan(10_000));
      }
    }

    private class QueryResult
    {
      public string Page { get; set; }

      public int Added { get; set; }
    }
  }
}