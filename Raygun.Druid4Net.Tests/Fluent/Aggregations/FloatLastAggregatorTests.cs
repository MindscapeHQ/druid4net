using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FloatLastAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new FloatLastAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "floatLast";
  }
}