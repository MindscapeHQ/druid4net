using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class DoubleLastAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new DoubleLastAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "doubleLast";
  }
}