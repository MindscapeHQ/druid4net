using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FloatFirstAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName)
    {
      return new FloatFirstAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "floatFirst";
  }
}