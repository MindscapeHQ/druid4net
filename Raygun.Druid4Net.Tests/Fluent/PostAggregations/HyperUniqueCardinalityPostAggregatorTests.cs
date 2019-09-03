using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class HyperUniqueCardinalityPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new HyperUniqueCardinalityPostAggregator("my_loaded", "loaded");
      Assert.That(spec.Type, Is.EqualTo("hyperUniqueCardinality"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new HyperUniqueCardinalityPostAggregator("my_loaded", "loaded");
      Assert.That(spec.Name, Is.EqualTo("my_loaded"));
      Assert.That(spec.FieldName, Is.EqualTo("loaded"));
    }
  }
}