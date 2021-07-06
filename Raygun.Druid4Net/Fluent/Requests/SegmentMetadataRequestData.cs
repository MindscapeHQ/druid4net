using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SegmentMetadataRequestData : QueryRequestData
  {
    public string QueryType => "segmentMetadata";

    public IToIncludeSpec ToInclude { get; }
    
    public bool Merge { get; }
    
    public IContextSpec Context { get; }
    
    public IEnumerable<AnalysisType> AnalysisTypes { get; }
    
    public bool LenientAggregatorMerge { get; }

    public SegmentMetadataRequestData(string dataSource, IList<string> intervals, IToIncludeSpec toInclude, bool merge, IContextSpec context, IEnumerable<AnalysisType> analysisTypes, bool lenientAggregatorMerge)
    {
      DataSource = dataSource;
      Intervals = intervals;
      ToInclude = toInclude;
      Merge = merge;
      Context = context;
      AnalysisTypes = analysisTypes;
      LenientAggregatorMerge = lenientAggregatorMerge;
    }
  }
}
