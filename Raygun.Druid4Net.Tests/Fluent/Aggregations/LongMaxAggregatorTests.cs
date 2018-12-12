using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class LongMaxAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new LongMaxAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "longMax";
  }
}