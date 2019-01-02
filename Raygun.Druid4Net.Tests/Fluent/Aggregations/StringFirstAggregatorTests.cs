using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class StringFirstAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string fieldName, string name = null)
    {
      return new StringFirstAggregator(fieldName, name);
    }

    protected override string ExpectedAggregatorType => "stringFirst";
    
    [Test]
    public void Constructor_WithAllProperties_AllValuesAreSet()
    {
      var aggregator = new StringFirstAggregator("test", "test_name", 2048, true);
      Assert.That(aggregator.FieldName, Is.EqualTo("test"));
      Assert.That(aggregator.Name, Is.EqualTo("test_name"));
      Assert.That(aggregator.MaxStringBytes, Is.EqualTo(2048));
      Assert.That(aggregator.FilterNullValues, Is.True);
    }
  }
}