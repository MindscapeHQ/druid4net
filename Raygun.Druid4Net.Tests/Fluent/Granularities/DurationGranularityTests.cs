using System;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests
{
  [TestFixture]
  public class DurationGranularityTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var granularity = new DurationGranularity(1000);
      Assert.That(granularity.Type, Is.EqualTo("duration"));
    }
    
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var granularity = new DurationGranularity(1000);
      Assert.That(granularity.Duration, Is.EqualTo(1000));
      Assert.That(granularity.Origin, Is.Null);
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var origin = DateTime.UtcNow;
      var granularity = new DurationGranularity(1000, origin);
      Assert.That(granularity.Duration, Is.EqualTo(1000));
      Assert.That(granularity.Origin, Is.EqualTo(origin));
    }
  }
}