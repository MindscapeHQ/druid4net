using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class ConstantPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new ConstantPostAggregator<int>("loaded", 123);
      Assert.That(spec.Type, Is.EqualTo("constant"));
    }
    
    [Test]
    public void Constructor_WithIntegerValue_PropertiesAreSet()
    {
      var spec = new ConstantPostAggregator<int>("loaded", 123);
      Assert.That(spec.Name, Is.EqualTo("loaded"));
      Assert.That(spec.Value, Is.EqualTo(123));
    }
    
    [Test]
    public void Constructor_WithDoubleValue_PropertiesAreSet()
    {
      var spec = new ConstantPostAggregator<double>("loaded", 123.45);
      Assert.That(spec.Value, Is.EqualTo(123.45));
    }
  }
}