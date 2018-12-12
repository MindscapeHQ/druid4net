using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class GreaterThanHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new GreaterThanHavingSpec("test_agg", 100);
      Assert.That(spec.Type, Is.EqualTo("greaterThan"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new GreaterThanHavingSpec("test_agg", 100);
      Assert.That(spec.Aggregation, Is.EqualTo("test_agg"));
      Assert.That(spec.Value, Is.EqualTo(100));
    }
  }
}