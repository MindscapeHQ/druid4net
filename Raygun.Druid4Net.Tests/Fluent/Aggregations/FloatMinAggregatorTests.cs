using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FloatMinAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new FloatMinAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "floatMin";
  }
}