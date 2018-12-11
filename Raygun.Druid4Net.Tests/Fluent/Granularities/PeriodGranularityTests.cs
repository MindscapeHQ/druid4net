using System;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests
{
  [TestFixture]
  public class PeriodGranularityTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var granularity = new PeriodGranularity("P2D");
      Assert.That(granularity.Type, Is.EqualTo("period"));
    }
    
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var granularity = new PeriodGranularity("P2D");
      Assert.That(granularity.Period, Is.EqualTo("P2D"));
      Assert.That(granularity.Origin, Is.Null);
      Assert.That(granularity.TimeZone, Is.Null);
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var origin = DateTime.UtcNow;
      var granularity = new PeriodGranularity("P2D", "America/Los_Angeles", origin);
      Assert.That(granularity.Period, Is.EqualTo("P2D"));
      Assert.That(granularity.Origin, Is.EqualTo(origin));
      Assert.That(granularity.TimeZone, Is.EqualTo("America/Los_Angeles"));
    }
  }
}