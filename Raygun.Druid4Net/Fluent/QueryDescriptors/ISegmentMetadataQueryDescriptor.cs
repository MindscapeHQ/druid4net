using System;
using System.Collections.Generic;
using Raygun.Druid4Net.ToInclude;

namespace Raygun.Druid4Net
{
    public interface ISegmentMetadataQueryDescriptor
    {
        ISegmentMetadataQueryDescriptor DataSource(string dataSource);
        
        ISegmentMetadataQueryDescriptor Interval(DateTime from, DateTime to);
        
        ISegmentMetadataQueryDescriptor Intervals(IEnumerable<Interval> intervals);

        ISegmentMetadataQueryDescriptor ToInclude(IToIncludeSpec toIncludeSpec);

        ISegmentMetadataQueryDescriptor Merge(bool merge);
        
        ISegmentMetadataQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);

        ISegmentMetadataQueryDescriptor AnalysisTypes(params AnalysisType[] analysisTypes);

        ISegmentMetadataQueryDescriptor LenientAggregatorMerge(bool lenientAggregatorMerge);

        IDruidRequest<SegmentMetadataRequestData> Generate();
    }
}
