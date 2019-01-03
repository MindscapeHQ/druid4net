using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class StringLastAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName)
    {
      return new StringLastAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "stringLast";
    
    [Test]
    public void Constructor_WithAllProperties_AllValuesAreSet()
    {
      var aggregator = new StringLastAggregator("test_name", "test", 2048, true);
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("test_name"));
      Assert.That(aggregator.MaxStringBytes, Is.EqualTo(2048));
      Assert.That(aggregator.FilterNullValues, Is.True);
    }
  }
}