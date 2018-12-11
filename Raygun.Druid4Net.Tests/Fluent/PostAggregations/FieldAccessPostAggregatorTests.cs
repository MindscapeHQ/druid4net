using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class FieldAccessPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new FieldAccessPostAggregator("loaded", "my_loaded");
      Assert.That(spec.Type, Is.EqualTo("fieldAccess"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new FieldAccessPostAggregator("loaded", "my_loaded");
      Assert.That(spec.Name, Is.EqualTo("loaded"));
      Assert.That(spec.FieldName, Is.EqualTo("my_loaded"));
    }
  }
}