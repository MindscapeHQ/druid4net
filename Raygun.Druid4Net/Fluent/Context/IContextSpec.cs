namespace Raygun.Druid4Net
{
  public interface IContextSpec
  {
    /// <summary>
    /// Query timeout in milliseconds, beyond which unfinished queries will be cancelled.
    /// </summary>
    /// <remarks>0 is no timeout</remarks>
    int? Timeout { get; set; }

    /// <summary>
    /// Maximum number of bytes gathered from data nodes such as historicals and realtime processes to execute a query. 
    /// This parameter can be used to further reduce maxScatterGatherBytes limit at query time.
    /// </summary>
    long? MaxScatterGatherBytes { get; set; }

    /// <summary>
    /// Query Priority. Queries with higher priority get precedence for computational resources.
    /// </summary>
    /// <remarks>default is 0</remarks>
    int? Priority { get; set; }

    /// <summary>
    /// Unique identifier given to this query. 
    /// If a query ID is set or known, this can be used to cancel the query.
    /// </summary>
    /// <remarks>auto-generated</remarks>
    string QueryId { get; set; }

    /// <summary>
    /// Flag indicating whether to leverage the query cache for this query. When set to false, it disables reading from the query cache for this query. 
    /// When set to true, Druid uses druid.broker.cache.useCache or druid.historical.cache.useCache to determine whether or not to read from the query cache
    /// </summary>
    /// <remarks>default is true</remarks>
    bool? UseCache { get; set; }

    /// <summary>
    /// Flag indicating whether to save the results of the query to the query cache. 
    /// Primarily used for debugging. 
    /// When set to false, it disables saving the results of this query to the query cache. 
    /// When set to true, Druid uses druid.broker.cache.populateCache or druid.historical.cache.populateCache to determine whether or not to save the results of this query to the query cache
    /// </summary>
    /// <remarks>default is true</remarks>
    bool? PopulateCache { get; set; }

    /// <summary>
    /// Return "by segment" results. Primarily used for debugging, setting it to true returns results associated with the data segment they came from.
    /// </summary>
    /// <remarks>default is false</remarks>
    bool? BySegment { get; set; }

    /// <summary>
    /// Flag indicating whether to "finalize" aggregation results. 
    /// Primarily used for debugging. 
    /// For instance, the hyperUnique aggregator will return the full HyperLogLog sketch instead of the estimated cardinality when this flag is set to false.
    /// </summary>
    /// <remarks>default is true</remarks>
    bool? Finalize { get; set; }

    /// <summary>
    /// At the broker node level, long interval queries (of any type) may be broken into shorter interval queries to parallelize merging more than normal. 
    /// Broken up queries will use a larger share of cluster resources, but may be able to complete faster as a result. 
    /// Use ISO 8601 periods. 
    /// For example, if this property is set to P1M (one month), then a query covering a year would be broken into 12 smaller queries. 
    /// The broker uses its query processing executor service to initiate processing for query chunks, so make sure "druid.processing.numThreads" is configured appropriately on the broker. 
    /// groupBy queries do not support chunkPeriod by default, although they do if using the legacy "v1" engine.
    /// </summary>
    /// <remarks>default is P0D (off)</remarks>
    string ChunkPeriod { get; set; }

    /// <summary>
    /// If true, DateTime is serialized as long in the result returned by broker and the data transportation between broker and compute node.
    /// </summary>
    /// <remarks>default is false</remarks>
    bool? SerializeDateTimeAsLong { get; set; }

    /// <summary>
    /// If true, DateTime is serialized as long in the data transportation between broker and compute node.
    /// </summary>
    /// <remarks>default is false</remarks>
    bool? SerializeDateTimeAsLongInner { get; set; }
    
    /// <summary>
    /// Overrides the brokers search strategy when a search query is performed.
    /// </summary>
    SearchStrategy? Strategy { get; set; }
  }
}