using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.Scan
{
  [TestFixture]
  public class ScanVirtualColumns : TestQueryBase
  {
    private const string VirtualColumnName = "cityCountry";
    
    private IList<QueryResult> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.Scan<QueryResult>(q => q
        .VirtualColumns(new []{
          new ExpressionVirtualColumn(
            VirtualColumnName,
           "concat(" + Wikipedia.Dimensions.CityName + " + ', ' + " + Wikipedia.Dimensions.CountryName + ")",
            ExpressionOutputType.STRING
          )
        })
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
      Assert.That(_results.First().CityCountry, Is.EqualTo("Hartsville, United States"));
      Assert.That(_results.First().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.First().CityName, Is.EqualTo("Hartsville"));
    }

    [Test]
    public void LastResultIsCorrect()
    {
      Assert.That(_results.Last().CityCountry, Is.EqualTo("Leland, United States"));
      Assert.That(_results.Last().CountryName, Is.EqualTo("United States"));
      Assert.That(_results.Last().CityName, Is.EqualTo("Leland"));
    }

    private class QueryResult
    {
      public string CityCountry { get; set; }
      public string CountryName { get; set; }
      public string CityName { get; set; }
    }
  }
}
