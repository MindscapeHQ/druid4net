using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SegmentMetadataRequestData : DatasourceQueryRequestData
  {
    public string QueryType => "segmentMetadata";
    public IList<string> Intervals { get; }
    public IToIncludeSpec ToInclude { get; }
    public bool Merge { get; }
    public IContextSpec Context { get; }
    public IEnumerable<AnalysisType> AnalysisTypes { get; }
    public bool LenientAggregatorMerge { get; }

    public SegmentMetadataRequestData(IDataSourceSpec dataSource, IList<string> intervals, IToIncludeSpec toInclude, bool merge, IContextSpec context, IEnumerable<AnalysisType> analysisTypes, bool lenientAggregatorMerge)
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
