using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SegmentMetadataQueryDescriptor : QueryDescriptor, ISegmentMetadataQueryDescriptor
  {
    internal IToIncludeSpec ToIncludeValue;

    internal bool MergeValue;

    internal ContextSpec ContextValue;

    internal IEnumerable<AnalysisType> AnalysisTypesValue;

    internal bool LenientAggregatorMergeValue;

    public SegmentMetadataQueryDescriptor()
    {
      ContextValue = new ContextSpec();
    }
    
    public ISegmentMetadataQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;
      return this;
    }
    
    public ISegmentMetadataQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      

      return this;
    }
    
    public ISegmentMetadataQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public ISegmentMetadataQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public ISegmentMetadataQueryDescriptor ToInclude(IToIncludeSpec toIncludeSpec)
    {
      ToIncludeValue = toIncludeSpec;
      return this;
    }

    public ISegmentMetadataQueryDescriptor Merge(bool merge)
    {
      MergeValue = merge;
      return this;
    }

    public ISegmentMetadataQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);
      return this;
    }

    public ISegmentMetadataQueryDescriptor AnalysisTypes(params AnalysisType[] analysisTypes)
    {
      AnalysisTypesValue = analysisTypes;
      return this;
    }

    public ISegmentMetadataQueryDescriptor LenientAggregatorMerge(bool lenientAggregatorMerge)
    {
      LenientAggregatorMergeValue = lenientAggregatorMerge;
      return this;
    }

    public IDruidRequest<SegmentMetadataRequestData> Generate()
    {
      var request = new SegmentMetadataRequest();
      request.Build(this);
      return request;
    }
  }
}
