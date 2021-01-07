using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNQueryDescriptor : AggregatableQueryDescriptor, ITopNQueryDescriptor
  {
    internal IDimensionSpec DimensionValue;

    internal ITopNMetricSpec MetricSpecValue;

    internal long ThresholdValue;

    internal TopNContextSpec ContextValue;

    public TopNQueryDescriptor()
    {
      ContextValue = new TopNContextSpec();
    }
    
    public ITopNQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns)
    {
      SetVirtualColumns(virtualColumns);
      
      return this;
    }

    public ITopNQueryDescriptor Dimension(string dimension)
    {
      DimensionValue = new DefaultDimension(dimension);

      return this;
    }

    public ITopNQueryDescriptor Dimension(IDimensionSpec dimension)
    {
      DimensionValue = dimension;

      return this;
    }

    public ITopNQueryDescriptor Metric(string metric)
    {
      MetricSpecValue = new NumericTopNMetricSpec(metric);

      return this;
    }

    public ITopNQueryDescriptor Metric(ITopNMetricSpec metricSpec)
    {
      MetricSpecValue = metricSpec;

      return this;
    }

    public ITopNQueryDescriptor Threshold(long threshold)
    {
      ThresholdValue = threshold;

      return this;
    }
    
    public ITopNQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }
    
    public ITopNQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }

    public ITopNQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }

    public ITopNQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }
    
    public ITopNQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      

      return this;
    }

    public ITopNQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public ITopNQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);

      return this;
    }
    
    public ITopNQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;

      return this;
    }

    public ITopNQueryDescriptor Granularity(Granularities granularity)
    {
      SetGranularity(granularity);
      
      return this;
    }
    
    public ITopNQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;

      return this;
    }

    public ITopNQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;

      return this;
    }

    public ITopNQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, int? minTopNThreshold = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.MinTopNThreshold = minTopNThreshold;

      return this;
    }

    public IDruidRequest<TopNRequestData> Generate()
    {
      var request = new TopNRequest();
      request.Build(this);

      return request;
    }
  }
}
