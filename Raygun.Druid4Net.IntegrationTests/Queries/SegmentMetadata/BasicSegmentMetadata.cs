using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.SegmentMetadata
{
  [TestFixture]
  public class BasicSegmentMetadata : TestQueryBase
  {
    private IList<SegmentMetadataResultItem> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.SegmentMetadata(q => q
        .DataSource(Wikipedia.DataSource)
        .Interval(FromDate, ToDate)
      );

      _results = response.Data.ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void QueryHasCorrectNumberOfRows()
    {
      Assert.That(_results.First().NumRows, Is.EqualTo(24433));
    }

    [Test]
    public void  CityNameColumnIsCorrect()
    {
      Assert.True(_results.First().Columns.ContainsKey(Wikipedia.Dimensions.CityName));
      Assert.That(_results.First().Columns[Wikipedia.Dimensions.CityName].Type, Is.EqualTo("STRING"));
    }
  }
}
