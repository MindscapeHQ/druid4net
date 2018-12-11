using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class SelectorFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new SelectorFilter("test_dimension", "test_value");
      Assert.That(filter.Type, Is.EqualTo("selector"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var filter = new SelectorFilter("test_dimension", "test_value");
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }
  }
}