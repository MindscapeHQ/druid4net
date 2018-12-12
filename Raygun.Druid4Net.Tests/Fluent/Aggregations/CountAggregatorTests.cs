using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class CountAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = new CountAggregator("test");
      Assert.That(aggregator.Type, Is.EqualTo("count"));
    }
    
    [Test]
    public void Constructor_WithName_NameIsSet()
    {
      var aggregator = new CountAggregator("test");
      Assert.That(aggregator.Name, Is.EqualTo("test"));
    }
  }
}