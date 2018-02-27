namespace Raygun.Druid4Net
{
  public class TopNContextSpec : ContextSpec
  {
    /// <summary>
    /// The top minTopNThreshold local results from each segment are returned for merging to determine the global topN.
    /// </summary>
    /// <remarks>default is 1000 if not set</remarks>
    public int? MinTopNThreshold { get; set; }
  }
}