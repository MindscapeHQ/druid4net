using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class QueryFilterHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new QueryFilterHavingSpec(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(spec.Type, Is.EqualTo("filter"));
    }
    
    [Test]
    public void Constructor_WithValues_PropertiesAreSet()
    {
      var spec = new QueryFilterHavingSpec(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(spec.Filter, Is.Not.Null);
      Assert.That(spec.Filter, Is.TypeOf<SelectorFilter>());
    }
  }
}