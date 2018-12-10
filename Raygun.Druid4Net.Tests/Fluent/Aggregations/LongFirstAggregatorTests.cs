using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class LongFirstAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new LongFirstAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "longFirst";
  }
}