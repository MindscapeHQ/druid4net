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

    [Test]
    public void ThresholdIsSet_SetsThresholdInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Threshold(10)).Generate();

      Assert.That(request.RequestData.Threshold, Is.EqualTo(10));
    }

    [Test]
    public void ContextMinTopNThresholdIsSet_SetsMinTopNThresholdInBody()
    {
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Context(minTopNThreshold: 500)).Generate();

      Assert.That(request.RequestData.Context.MinTopNThreshold, Is.EqualTo(500));
    }
  }
}