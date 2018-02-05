using System.Runtime.Serialization;

namespace Raygun.Druid4Net
{
  public class ContextSpec
  {
    internal const int DefaultTimeout = 60 * 1000;

    /// <summary>
    /// Disable timeseries zero-filling behavior, so only buckets with results will be returned.
    /// </summary>
    /// <remarks>default is false</remarks>
    public bool? SkipEmptyBuckets { get; }

    /// <summary>
    /// Default groupBy query strategy.
    /// </summary>
    /// <remarks>default is v2</remarks>
    public string GroupByStrategy { get; }

    /// <summary>
    /// Can be used to lower the value of druid.query.groupBy.maxOnDiskStorage for this query.
    /// </summary>
    public long? MaxOnDiskStorage { get; }

    /// <summary>
    /// Query timeout in milliseconds, beyond which unfinished queries will be cancelled.
    /// </summary>
    /// <remarks>0 is no timeout</remarks>
    [DataMember(Name = "timeout")]
    public int Timeout { get; }

    /// <summary>
    /// Query Priority. Queries with higher priority get precedence for computational resources.
    /// </summary>
    /// <remarks>default is 0</remarks>
    public int? Priority { get; }

    /// <summary>
    /// The top minTopNThreshold local results from each segment are returned for merging to determine the global topN.
    /// </summary>
    /// <remarks>default is 1000 if not set</remarks>
    public int? MinTopNThreshold { get; }

    public ContextSpec()
    {
      // Assign defaults
      Timeout = DefaultTimeout;
    }
  }
}
