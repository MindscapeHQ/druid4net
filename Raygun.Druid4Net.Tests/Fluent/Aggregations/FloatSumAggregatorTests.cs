using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FloatSumAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new FloatSumAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "floatSum";
  }
}