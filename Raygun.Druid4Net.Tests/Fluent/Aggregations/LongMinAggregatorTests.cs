using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class LongMinAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new LongMinAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "longMin";
  }
}