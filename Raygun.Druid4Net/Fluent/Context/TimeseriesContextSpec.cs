namespace Raygun.Druid4Net
{
  public class TimeseriesContextSpec : ContextSpec
  {
    /// <summary>
    /// Disable timeseries zero-filling behavior, so only buckets with results will be returned.
    /// </summary>
    /// <remarks>default is false</remarks>
    public bool? SkipEmptyBuckets { get; set; }
  }
}