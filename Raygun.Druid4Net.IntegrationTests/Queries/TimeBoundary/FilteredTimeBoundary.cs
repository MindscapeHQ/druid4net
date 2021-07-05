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
        .Filter(new SelectorFilter(Wikipedia.Dimensions.IsAnonymous, "true"))
        .DataSource(Wikipedia.DataSource)
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
      Assert.That(_results.First().Timestamp, Is.EqualTo(new DateTime(2016, 6, 27, 0, 0, 34, 959, DateTimeKind.Utc)));
      Assert.That(_results.First().Result.MinTime, Is.EqualTo(new DateTime(2016, 6, 27, 0, 0, 34, 959, DateTimeKind.Utc)));
      Assert.That(_results.First().Result.MaxTime, Is.EqualTo(new DateTime(2016, 6, 27, 21, 30, 50, 804, DateTimeKind.Utc)));
    }
  }
}