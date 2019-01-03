using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FilteredAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = new FilteredAggregator(null, null);
      Assert.That(aggregator.Type, Is.EqualTo("filtered"));
    }
    
    [Test]
    public void Constructor_WithName_NameIsSet()
    {
      var filter = new SelectorFilter("test", "value");
      var agg = new CountAggregator("test");
      
      var aggregator = new FilteredAggregator(filter, agg);
      Assert.That(aggregator.Filter, Is.EqualTo(filter));
      Assert.That(aggregator.Aggregator, Is.EqualTo(agg));
    }
  }
}