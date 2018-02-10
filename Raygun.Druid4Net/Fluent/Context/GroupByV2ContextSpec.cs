namespace Raygun.Druid4Net
{
  public class GroupByV2ContextSpec : ContextSpec
  {
    /// <summary>
    /// Overrides the value of druid.query.groupBy.defaultStrategy for this query.
    /// </summary>
    public string GroupByStrategy { get; set; }

    /// <summary>
    /// Can be used to lower the value of druid.query.groupBy.maxOnDiskStorage for this query.
    /// </summary>
    public long? MaxOnDiskStorage { get; set; }

  }
}