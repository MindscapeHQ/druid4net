namespace Raygun.Druid4Net
{
  internal class SegmentMetadataRequest : IDruidRequest<SegmentMetadataRequestData>
  {
    public SegmentMetadataRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ISegmentMetadataQueryDescriptor
    {
      var qd = queryDescriptor as SegmentMetadataQueryDescriptor;

      RequestData = new SegmentMetadataRequestData(qd.DataSourceValue, qd.IntervalsValue, qd.ToIncludeValue, qd.MergeValue, qd.ContextValue, qd.AnalysisTypesValue, qd.LenientAggregatorMergeValue);
    }
  }
}
