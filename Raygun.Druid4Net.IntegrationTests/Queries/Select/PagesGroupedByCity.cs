using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Select
{
  [TestFixture]
  public class SelectSpecificPagedData : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Select<SelectResult<QueryResult>>(q => q
        .Dimensions(Wikiticker.Dimensions.CountryName, Wikiticker.Dimensions.CityName, Wikiticker.Dimensions.Page)
        .Metrics(Wikiticker.Metrics.Added, Wikiticker.Metrics.Deleted)
        .Paging(new PagingSpec(10))
        .Filter(new SelectorFilter(Wikiticker.Dimensions.IsAnonymous, "true"))
        .DataSource(Wikiticker.DataSource)
        .Interval(FromDate, ToDate)
      );

      _results = response.Data.Result.Events.Select(x => x.Event).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(10));
    }

//    [Test]
//    public void FirstResultIsCorrect()
//    {
//      Assert.That(_results.First().Page, Is.EqualTo("Wikipedia:Vandalismusmeldung"));
//      Assert.That(_results.First().Count, Is.EqualTo(33));
//    }
//
//    [Test]
//    public void LastResultIsCorrect()
//    {
//      Assert.That(_results.Last().Page, Is.EqualTo("Wikipedia:Requests for page protection"));
//      Assert.That(_results.Last().Count, Is.EqualTo(17));
//    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public string CityName { get; set; }
      public string Page { get; set; }
      public int Count { get; set; }
    }
  }
}