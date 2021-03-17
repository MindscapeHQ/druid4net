using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class DimensionSelectorHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new DimensionSelectorHavingSpec("test_agg", "test_value");
      Assert.That(spec.Type, Is.EqualTo("dimSelector"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new DimensionSelectorHavingSpec("test_agg", "test_value");
      Assert.That(spec.Dimension, Is.EqualTo("test_agg"));
      Assert.That(spec.Value, Is.EqualTo("test_value"));
    }
  }
}