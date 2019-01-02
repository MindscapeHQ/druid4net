using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class HyperUniqueAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName)
    {
      return new HyperUniqueAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "hyperUnique";

    [Test]
    public void Constructor_WithAllValues_AllPropertiesAreSet()
    {
      var aggregator = new HyperUniqueAggregator("test", "test_field", true, true);
      Assert.That(aggregator.FieldName, Is.EqualTo("test_field"));
      Assert.That(aggregator.Name, Is.EqualTo("test"));
      Assert.That(aggregator.IsInputHyperUnique, Is.True);
      Assert.That(aggregator.Round, Is.True);
    }
  }
}