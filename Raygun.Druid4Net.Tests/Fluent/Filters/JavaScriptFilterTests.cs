using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class JavaScriptFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new JavaScriptFilter("test_dimension", "function(x) { return x == 1; }");
      Assert.That(filter.Type, Is.EqualTo("javascript"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var filter = new JavaScriptFilter("test_dimension", "function(x) { return x == 1; }");
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));
      Assert.That(filter.Function, Is.EqualTo("function(x) { return x == 1; }"));
    }
  }
}