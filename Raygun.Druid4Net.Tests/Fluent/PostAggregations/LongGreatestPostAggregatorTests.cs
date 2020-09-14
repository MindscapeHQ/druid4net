using System.Collections.Generic;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class LongGreatestPostAggregatorTests : PostAggregatorTestBase
  {
    protected override BasePostAggregator GetPostAggregatorParams(string name, IPostAggregationSpec fieldA, IPostAggregationSpec fieldB)
    {
      return new LongGreatestPostAggregator(name, fieldA, fieldB);
    }

    protected override BasePostAggregator GetPostAggregatorEnumerable(string name, IPostAggregationSpec fieldA, IPostAggregationSpec fieldB)
    {
      return new LongGreatestPostAggregator(name, new List<IPostAggregationSpec> {fieldA, fieldB});
    }

    protected override string ExpectedAggregatorType => "longGreatest";
  }
}