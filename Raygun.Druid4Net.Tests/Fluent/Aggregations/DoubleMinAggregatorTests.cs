using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class DoubleMinAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName)
    {
      return new DoubleMinAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "doubleMin";
  }
}