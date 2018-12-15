using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SelectQueryDescriptor : QueryDescriptor, ISelectQueryDescriptor
  {
    internal PagingSpec PagingSpecValue;

    internal bool DescendingValue;

    internal IEnumerable<string> MetricsValue;

    internal IEnumerable<string> DimensionsValue;

    internal ContextSpec ContextValue;

    public SelectQueryDescriptor()
    {
      ContextValue = new ContextSpec();
    }

    public ISelectQueryDescriptor Metrics(params string[] metrics)
    {
      MetricsValue = metrics;
      return this;
    }

    public ISelectQueryDescriptor Metrics(IEnumerable<string> metrics)
    {
      MetricsValue = metrics;
      return this;
    }

    public ISelectQueryDescriptor Dimensions(params string[] dimensions)
    {
      DimensionsValue = dimensions;
      return this;
    }

    public ISelectQueryDescriptor Dimensions(IEnumerable<string> dimensions)
    {
      DimensionsValue = dimensions;
      return this;
    }

    public ISelectQueryDescriptor Paging(PagingSpec pagingSpec)
    {
      PagingSpecValue = pagingSpec;
      return this;
    }

    public ISelectQueryDescriptor Descending(bool descending)
    {
      DescendingValue = descending;
      return this;
    }
    
    public ISelectQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      

      return this;
    }

    public ISelectQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public ISelectQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);

      return this;
    }
    
    public ISelectQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;

      return this;
    }

    public ISelectQueryDescriptor Granularity(Granularities granularity)
    {
      SetGranularity(granularity);
      
      return this;
    }
    
    public ISelectQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;

      return this;
    }

    public ISelectQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;

      return this;
    }
    
    public ISelectQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      return this;
    }

    public IDruidRequest<SelectRequestData> Generate()
    {
      var request = new SelectRequest();
      request.Build(this);

      return request;
    }
  }
}
