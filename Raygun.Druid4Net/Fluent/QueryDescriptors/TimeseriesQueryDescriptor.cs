using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeseriesQueryDescriptor : AggregatableQueryDescriptor, ITimeseriesQueryDescriptor
  {
    internal bool DescendingValue;

    internal TimeseriesContextSpec ContextValue;

    public TimeseriesQueryDescriptor()
    {
      ContextValue = new TimeseriesContextSpec();
    }

    public ITimeseriesQueryDescriptor Descending(bool descending)
    {
      DescendingValue = descending;

      return this;
    }
    
    public ITimeseriesQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }
    
    public ITimeseriesQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }

    public ITimeseriesQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }

    public ITimeseriesQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }
    
    public ITimeseriesQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      

      return this;
    }

    public ITimeseriesQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public ITimeseriesQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);

      return this;
    }
    
    public ITimeseriesQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;

      return this;
    }

    public ITimeseriesQueryDescriptor Granularity(Granularities granularity)
    {
      SetGranularity(granularity);
      
      return this;
    }
    
    public ITimeseriesQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;

      return this;
    }

    public ITimeseriesQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;

      return this;
    }

    public ITimeseriesQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, bool? skipEmptyBuckets = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.SkipEmptyBuckets = skipEmptyBuckets;

      return this;
    }

    public IDruidRequest<TimeseriesRequestData> Generate()
    {
      var request = new TimeseriesRequest();
      request.Build(this);

      return request;
    }
  }
}
