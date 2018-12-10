using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class AggregatableQueryDescriptorTests
  {
    [Test]
    public void SumAggregationIsSet_SetsAggregationInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Aggregations(new LongSumAggregator("sum_count", "count"))).Generate();

      var agg = request.RequestData.Aggregations.First() as LongSumAggregator;

      Assert.IsNotNull(agg);
      Assert.That(agg.Type, Is.EqualTo("longSum"));
      Assert.That(agg.Name, Is.EqualTo("sum_count"));
      Assert.That(agg.FieldName, Is.EqualTo("count"));
    }

    [Test]
    public void ArithmeticPostAggregataionIsSet_SetsPostAggregationInBody()
    {
      var fields = new List<IPostAggregationSpec> {new FieldAccessPostAggregator("loaded", "my_loaded"), new FieldAccessPostAggregator("total", "my_total") };
      var aggregations = new List<IPostAggregationSpec> {new ArithmeticPostAggregator("average", fields, ArithmeticFunction.Divide) };
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().PostAggregations(aggregations)).Generate();

      var agg = request.RequestData.PostAggregations.First() as ArithmeticPostAggregator;

      Assert.IsNotNull(agg);
      Assert.That(agg.Type, Is.EqualTo("arithmetic"));
      Assert.That(agg.Name, Is.EqualTo("average"));
      Assert.That(agg.Fn, Is.EqualTo("/"));

      var field1 = agg.Fields.First() as FieldAccessPostAggregator;

      Assert.IsNotNull(field1);
      Assert.That(field1.Type, Is.EqualTo("fieldAccess"));
      Assert.That(field1.Name, Is.EqualTo("loaded"));
      Assert.That(field1.FieldName, Is.EqualTo("my_loaded"));

      var field2 = agg.Fields.Last() as FieldAccessPostAggregator;
      Assert.IsNotNull(field2);
      Assert.That(field2.Type, Is.EqualTo("fieldAccess"));
      Assert.That(field2.Name, Is.EqualTo("total"));
      Assert.That(field2.FieldName, Is.EqualTo("my_total"));
    }
  }
}