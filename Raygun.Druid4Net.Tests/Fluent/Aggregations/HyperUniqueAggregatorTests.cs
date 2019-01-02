using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class HyperUniqueAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = new HyperUniqueAggregator("test");
      Assert.That(aggregator.Type, Is.EqualTo("hyperUnique"));
    }
    
    [Test]
    public void Constructor_WithFieldNameOnly_NameIsSet()
    {
      var aggregator = new HyperUniqueAggregator("test");
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("test"));
      Assert.That(aggregator.IsInputHyperUnique, Is.False);
      Assert.That(aggregator.Round, Is.False);
    }
    
    [Test]
    public void Constructor_WithAllValues_AllPropertiesAreSet()
    {
      var aggregator = new HyperUniqueAggregator("test", "test_name", true, true);
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("test_name"));
      Assert.That(aggregator.IsInputHyperUnique, Is.True);
      Assert.That(aggregator.Round, Is.True);
    }
  }
}