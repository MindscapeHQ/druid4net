using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class LikeFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new LikeFilter("test_dimension", "foo*");
      Assert.That(filter.Type, Is.EqualTo("like"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var filter = new LikeFilter("test_dimension", "foo*");
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));
      Assert.That(filter.Pattern, Is.EqualTo("foo*"));
      Assert.That(filter.Escape, Is.Null);
    }
    
    [Test]
    public void Constructor_WithSpecificEscapeCharacter_EscapeIsSet()
    {
      var filter = new LikeFilter("test_dimension", "foo*", "o");
      Assert.That(filter.Escape, Is.EqualTo("o"));
    }
  }
}