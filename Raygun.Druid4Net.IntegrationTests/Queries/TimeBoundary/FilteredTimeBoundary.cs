using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TimeBoundary
{
  [TestFixture]
  public class FilteredTimeBoundary : TestQueryBase
  {
    private List<TimeBoundaryResultList> _results;

    [SetUp]
    public void Execute()
    {
      var response = DruidClient.TimeBoundary(q => q
        .Filter(new SelectorFilter(Wikiticker.Dimensions.IsAnonymous, "true"))
        .DataSource(Wikiticker.DataSource)
      );

      _results = response.Data.ToList();
    }

    [Test]
    public void QueryHasCorrectNumberOfResults()
    {
      Assert.That(_results.Count, Is.EqualTo(1));
    }

    [Test]
    public void ResultHasCorrectValues()
    {
      Assert.That(_results.First().Timestamp, Is.EqualTo(new DateTime(2015, 9, 12, 0, 47, 5, 474, DateTimeKind.Utc)));
      Assert.That(_results.First().Result.MinTime, Is.EqualTo(new DateTime(2015, 9, 12, 0, 47, 5, 474, DateTimeKind.Utc)));
      Assert.That(_results.First().Result.MaxTime, Is.EqualTo(new DateTime(2015, 9, 12, 23, 59, 9, 812, DateTimeKind.Utc)));
    }
  }
}