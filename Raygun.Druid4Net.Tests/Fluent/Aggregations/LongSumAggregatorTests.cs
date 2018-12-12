using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class LongSumAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new LongSumAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "longSum";
  }
}