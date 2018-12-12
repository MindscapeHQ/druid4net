using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class RegexFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new RegexFilter("test_dimension", "\\d");
      Assert.That(filter.Type, Is.EqualTo("regex"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var filter = new RegexFilter("test_dimension", "\\d");
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));
      Assert.That(filter.Pattern, Is.EqualTo("\\d"));
    }
  }
}