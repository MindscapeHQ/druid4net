using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class DoubleMaxAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new DoubleMaxAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "doubleMax";
  }
}