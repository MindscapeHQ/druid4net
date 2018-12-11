using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class FinalizingFieldAccessPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new FinalizingFieldAccessPostAggregator("loaded", "my_loaded");
      Assert.That(spec.Type, Is.EqualTo("finalizingFieldAccess"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new FinalizingFieldAccessPostAggregator("loaded", "my_loaded");
      Assert.That(spec.Name, Is.EqualTo("loaded"));
      Assert.That(spec.FieldName, Is.EqualTo("my_loaded"));
    }
  }
}