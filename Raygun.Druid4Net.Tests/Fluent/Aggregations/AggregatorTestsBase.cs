using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public abstract class AggregatorTestsBase
  {
    protected abstract BaseAggregator GetAggregator(string fieldName, string name = null);
    protected abstract string ExpectedAggregatorType { get; }
    
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = GetAggregator("test");
      Assert.That(aggregator.Type, Is.EqualTo(ExpectedAggregatorType));
    }
    
    [Test]
    public void Constructor_WithFieldName_FieldNameIsSet()
    {
      var aggregator = GetAggregator("test");
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("test"));
    }
    
    [Test]
    public void Constructor_WithName_NameIsSet()
    {
      var aggregator = GetAggregator("test", "another");
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("another"));
    }
  }
}