using System;
using System.Collections.Generic;
using NUnit.Framework;
using Raygun.Druid4Net.Fluent.Aggregations;
using Raygun.Druid4Net.Fluent.Metrics;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class TopNQueryDescriptorTests
  {
    [Test]
    public void DatasourceIsSet_SetsDatasourceInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().DataSource("test_datasource")).Generate();

      const string expectedBody = "{\"threshold\":0,\"granularity\":\"all\",\"intervals\":[],\"context\":{\"timeout\":60000},\"dataSource\":\"test_datasource\",\"queryType\":\"topN\"}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void InvervalsAreSet_SetsIntervalsInBody()
    {
      var fromDate = DateTime.Parse("2017-10-01T14:45:22.123");
      var toDate = DateTime.Parse("2017-10-02T10:35:21.345");
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Intervals(fromDate, toDate)).Generate();

      const string expectedBody = "{\"threshold\":0,\"granularity\":\"all\",\"intervals\":[\"2017-10-01T14:45:22Z/2017-10-02T10:35:21Z\"],\"context\":{\"timeout\":60000},\"queryType\":\"topN\"}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void GranularityIsSet_SetsGranularityInBody()
    {
      var request = ((TopNQueryDescriptor)new TopNQueryDescriptor().Granularity(Granularities.Day)).Generate();

      const string expectedBody = "{\"threshold\":0,\"granularity\":\"day\",\"intervals\":[],\"context\":{\"timeout\":60000},\"queryType\":\"topN\"}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void DimensionIsSet_SetsDimensionInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Dimension("test_dim")).Generate();

      const string expectedBody = "{\"threshold\":0,\"granularity\":\"all\",\"intervals\":[],\"context\":{\"timeout\":60000},\"dimension\":\"test_dim\",\"queryType\":\"topN\"}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void MetricIsSet_SetsMetricInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Metric(new NumericTopNMetricSpec("test_metric"))).Generate();

      const string expectedBody = "{\"threshold\":0,\"metric\":{\"type\":\"numeric\",\"metric\":\"test_metric\"},\"granularity\":\"all\",\"intervals\":[],\"context\":{\"timeout\":60000},\"queryType\":\"topN\"}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void BasicFilterIsSet_SetsFilterInBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Filter(new SelectorFilter("test_dim", "test_value"))).Generate();

      const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":0,\"filter\":{\"type\":\"selector\",\"dimension\":\"test_dim\",\"value\":\"test_value\"},\"context\":{\"timeout\":60000}}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void SumAggregationIsSet_SetsAggregationInBody()
    {
      var aggregations = new List<IAggregationSpec> {new LongSumAggregator("count", "sum_count")};
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Aggregations(aggregations)).Generate();

      const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":0,\"aggregations\":[{\"type\":\"longSum\",\"name\":\"sum_count\",\"fieldName\":\"count\"}],\"context\":{\"timeout\":60000}}";
      Assert.AreEqual(expectedBody, request.Body);
    }

    [Test]
    public void ThresholdIsSet_SetsThresholdBody()
    {
      var request = ((TopNQueryDescriptor) new TopNQueryDescriptor().Threshold(10)).Generate();

      const string expectedBody = "{\"queryType\":\"topN\",\"granularity\":\"all\",\"threshold\":10,\"context\":{\"timeout\":60000}}";
      Assert.AreEqual(expectedBody, request.Body);
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