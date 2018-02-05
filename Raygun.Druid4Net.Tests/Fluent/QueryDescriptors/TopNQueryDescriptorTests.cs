using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TopNQueryDescriptorTests
  {
    [Test]
    public void DatasourceIsSet_SetsDatasourceInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().DataSource("test_datasource")).Generate();

      Assert.That(request.RequestData.DataSource, Is.EqualTo("test_datasource"));
    }

    [Test]
    public void InvervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Intervals(fromDate, toDate)).Generate();

      Assert.That(request.RequestData.Intervals.First(), Is.EqualTo("2017-10-01T14:45:22Z/2017-10-02T10:35:21Z"));
    }

    [Test]
    public void GranularityIsSet_SetsGranularityInBody()
    {
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Granularity(Granularities.Day)).Generate();

      Assert.That(request.RequestData.Granularity, Is.EqualTo("day"));
    }

    [Test]
    public void DimensionIsSet_SetsDimensionInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Dimension("test_dim")).Generate();

      Assert.That(request.RequestData.Dimension, Is.EqualTo("test_dim"));
    }

    [Test]
    public void MetricIsSet_SetsMetricInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Metric(new NumericTopNMetricSpec("test_metric"))).Generate();

      var metric = request.RequestData.Metric as NumericTopNMetricSpec;

      Assert.IsNotNull(metric);
      Assert.That(metric.Type, Is.EqualTo("numeric"));
      Assert.That(metric.Metric, Is.EqualTo("test_metric"));
    }

    [Test]
    public void BasicFilterIsSet_SetsFilterInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Filter(new SelectorFilter("test_dim", "test_value"))).Generate();

      var filter = request.RequestData.Filter as SelectorFilter;

      Assert.IsNotNull(filter);
      Assert.That(filter.Type, Is.EqualTo("selector"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dim"));
      Assert.That(filter.Value, Is.EqualTo("test_value"));
    }

    [Test]
    public void SumAggregationIsSet_SetsAggregationInBody()
    {
      var aggregations = new List<IAggregationSpec> {new LongSumAggregator("sum_count", "count")};
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Aggregations(aggregations)).Generate();

      var agg = request.RequestData.Aggregations.First() as LongSumAggregator;

      Assert.IsNotNull(agg);
      Assert.That(agg.Type, Is.EqualTo("longSum"));
      Assert.That(agg.Name, Is.EqualTo("sum_count"));
      Assert.That(agg.FieldName, Is.EqualTo("count"));
    }

    [Test]
    public void ThresholdIsSet_SetsThresholdBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Threshold(10)).Generate();

      Assert.That(request.RequestData.Threshold, Is.EqualTo(10));
    }

    //[Test]
    //public void ContextTimeoutIsSet_OverridesTimeoutInBody()
    //{

    //  var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Context(1000)).Generate();

    //  const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":0,\"context\":{\"timeout\":1000}}";
    //  Assert.AreEqual(expectedBody, request.Body);
    //}

    //[Test]
    //public void ContextPriorityIsSet_SetsPriorityInBody()
    //{

    //  var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Context(0, 10)).Generate();

    //  const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":0,\"context\":{\"timeout\":60000,\"priority\":10}}";
    //  Assert.AreEqual(expectedBody, request.Body);
    //}

    //[Test]
    //public void MultipleContextCalls_CombinesAllPropertiesInContext()
    //{

    //  var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Context(1000).Context(true).Context("v2", 100)).Generate();

    //  const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":0,\"context\":{\"skipEmptyBuckets\":true,\"groupByStrategy\":\"v2\",\"maxOnDiskStorage\":100,\"timeout\":1000}}";
    //  Assert.AreEqual(expectedBody, request.Body);
    //}
  }
}