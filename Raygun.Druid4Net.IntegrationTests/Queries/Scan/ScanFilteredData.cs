using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Scan
{
  [TestFixture]
  public class ScanFilteredData : TestQueryBase
  {
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Scan<QueryResult>(q => q
        .Filter(new SelectorFilter(Wikipedia.Dimensions.CountryCode, "US"))
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
        .Limit(3)
      );

      _results = response.Data.SelectMany(x => x.Events).ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(3));
    }

    [Test]
    public void FirstResultIsCorrect()
    {
      Assert.That(_results.First().__time, Is.EqualTo(1466985779759));
      Assert.That(_results.First().Page, Is.EqualTo("Deaton-Flanigen Productions"));
      Assert.That(_results.First().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.First().CityName, Is.EqualTo("Hartsville"));
      Assert.That(_results.First().Added, Is.EqualTo(1));
      Assert.That(_results.First().Deleted, Is.EqualTo(0));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().__time, Is.EqualTo(1466986145633));
      Assert.That(_results.Last().Page, Is.EqualTo("Big Brother 17 (U.S.)"));
      Assert.That(_results.Last().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.Last().CityName, Is.EqualTo("Leland"));
      Assert.That(_results.Last().Added, Is.EqualTo(9));
      Assert.That(_results.Last().Deleted, Is.EqualTo(0));
    }

    private class QueryResult
    {
      public long __time { get; set; }
      public string CountryName { get; set; }
      public string CityName { get; set; }
      public string Page { get; set; }
      public int Added { get; set; }
      public int Deleted { get; set; }
    }
  }
}