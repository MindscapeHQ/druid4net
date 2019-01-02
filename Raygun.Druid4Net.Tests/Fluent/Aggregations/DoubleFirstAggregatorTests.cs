using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class DoubleFirstAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName)
    {
      return new DoubleFirstAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "doubleFirst";
  }
}