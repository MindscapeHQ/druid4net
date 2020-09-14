namespace Raygun.Druid4Net
{
  internal class ScanRequest : IDruidRequest<ScanRequestData>
  {
    public ScanRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : IScanQueryDescriptor
    {
      var qd = queryDescriptor as ScanQueryDescriptor;

      RequestData = new ScanRequestData(qd.DataSourceValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.ColumnsValue, qd.ResultFormatValue, qd.LimitValue, qd.OrderValue, qd.BatchSizeValue);
    }
  }
}
