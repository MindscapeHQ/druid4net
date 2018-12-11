using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class EqualToHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new EqualToHavingSpec("test_agg", 100);
      Assert.That(spec.Type, Is.EqualTo("equalTo"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new EqualToHavingSpec("test_agg", 100);
      Assert.That(spec.Aggregation, Is.EqualTo("test_agg"));
      Assert.That(spec.Value, Is.EqualTo(100));
    }
  }
}