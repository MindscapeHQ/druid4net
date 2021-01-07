using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Scan
{
  [TestFixture]
  public class ScanVirtualColumns : TestQueryBase
  {
    public const string VIRTUAL_COLUMN_NAME = "CityCountry";
    
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Scan<QueryResult>(q => q
        .VirtualColumns(new []{
          new ExpressionVirtualColumn(
            VIRTUAL_COLUMN_NAME,
           "concat(" + Wikiticker.Dimensions.CityName + " + ', ' + " + Wikiticker.Dimensions.CountryName + ")",
            ExpressionOutputType.STRING
          )
        })
        .Filter(new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US"))
        .DataSource(Wikiticker.DataSource)
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
      Assert.That(VIRTUAL_COLUMN_NAME, Is.EqualTo("Campbell, United States"));
      Assert.That(_results.First().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.First().CityName, Is.EqualTo("Campbell"));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(VIRTUAL_COLUMN_NAME, Is.EqualTo("Charlotte, United States"));
      Assert.That(_results.Last().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.Last().CityName, Is.EqualTo("Charlotte"));
    }

    private class QueryResult
    {
      public string CountryName { get; set; }
      public string CityName { get; set; }
    }
  }
}
