namespace Raygun.Druid4Net
{
  internal class TimeBoundaryRequest : IDruidRequest<TimeBoundaryRequestData>
  {
    public TimeBoundaryRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ITimeBoundaryQueryDescriptor
    {
      var qd = queryDescriptor as TimeBoundaryQueryDescriptor;

      RequestData = new TimeBoundaryRequestData(qd.DataSourceValue, qd.BoundValue, qd.FilterValue, qd.ContextValue);
    }
  }
}
