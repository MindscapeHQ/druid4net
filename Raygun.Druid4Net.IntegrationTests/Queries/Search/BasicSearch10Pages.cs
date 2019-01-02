using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Search
{
  [TestFixture]
  public class BasicSearch10Pages : TestQueryBase
  {
    private IList<SearchResultItem> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Search(q => q
        .DataSource(Wikiticker.DataSource)
        .Granularity(Granularities.All)
        .SearchDimensions(Wikiticker.Dimensions.Page)
        .Query(new ContainsSearchQuery("Dragon"))
        .Limit(10)
        .Interval(FromDate, ToDate)
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
      Assert.That(_results.First().Dimension, Is.EqualTo(Wikiticker.Dimensions.Page));
      Assert.That(_results.First().Value, Is.EqualTo("Alignment (Dungeons & Dragons)"));
      Assert.That(_results.First().Count, Is.EqualTo(1));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Dimension, Is.EqualTo(Wikiticker.Dimensions.Page));
      Assert.That(_results.Last().Value, Is.EqualTo("Episodi di Dragon Ball Super"));
      Assert.That(_results.Last().Count, Is.EqualTo(1));
    }
  }
}