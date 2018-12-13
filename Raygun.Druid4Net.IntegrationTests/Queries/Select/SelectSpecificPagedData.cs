using System;
using System.Collections.Generic;
using System.Data;
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

      _results = response.Data.SelectMany(x => x.Result.Events).Select(x => x.Event).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(10));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().Timestamp, Is.EqualTo(new DateTime(2015, 9, 12, 0, 47, 5, 474, DateTimeKind.Utc)));
      Assert.That(_results.First().Page, Is.EqualTo("Peremptory norm"));
      Assert.That(_results.First().CountryName, Is.EqualTo("Australia"));
      Assert.That(_results.First().CityName, Is.EqualTo("Auburn"));
      Assert.That(_results.First().Added, Is.EqualTo(0));
      Assert.That(_results.First().Deleted, Is.EqualTo(0));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().Timestamp, Is.EqualTo(new DateTime(2015, 9, 12, 0, 49, 31, 468, DateTimeKind.Utc)));
      Assert.That(_results.Last().Page, Is.EqualTo("\ud5a5\uac00"));
      Assert.That(_results.Last().CountryName, Is.EqualTo("Republic of Korea"));
      Assert.That(_results.Last().CityName, Is.Null);
      Assert.That(_results.Last().Added, Is.EqualTo(357));
      Assert.That(_results.Last().Deleted, Is.EqualTo(0));
    }

    private class QueryResult
    {
      public DateTime Timestamp { get; set; }
      public string CountryName { get; set; }
      public string CityName { get; set; }
      public string Page { get; set; }
      public int Added { get; set; }
      public int Deleted { get; set; }
    }
  }
}