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
        .DataSource(Wikiticker.DataSource)
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
      Assert.That(_results.First().NumRows, Is.EqualTo(10));
    }

    [Test]
    public void CityNameColumnIsCorrect()
    {
      Assert.True(_results.First().Columns.ContainsKey(Wikiticker.Dimensions.CityName));
      Assert.That(_results.First().Columns[Wikiticker.Dimensions.CityName].Type, Is.EqualTo(SegmentMetadataColumnType.STRING));
    }
  }
}
