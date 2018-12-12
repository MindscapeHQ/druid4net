using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class FloatMaxAggregatorTests : AggregatorTestsBase
  {
    protected override BaseAggregator GetAggregator(string name, string fieldName = null)
    {
      return new FloatMaxAggregator(name, fieldName);
    }

    protected override string ExpectedAggregatorType => "floatMax";
  }
}