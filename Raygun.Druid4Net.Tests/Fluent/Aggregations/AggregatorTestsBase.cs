using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public abstract class AggregatorTestsBase
  {
    protected abstract BaseAggregator GetAggregator(string name, string fieldName);
    protected abstract string ExpectedAggregatorType { get; }
    
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = GetAggregator("test", "another");
      Assert.That(aggregator.Type, Is.EqualTo(ExpectedAggregatorType));
    }
    
    [Test]
    public void Constructor_WithNameAndFieldName_ValuesAreSet()
    {
      var aggregator = GetAggregator("test", "another");
      Assert.That(aggregator.Name, Is.EqualTo("test"));
      Assert.That(aggregator.FieldName, Is.EqualTo("another"));
    }
  }
}