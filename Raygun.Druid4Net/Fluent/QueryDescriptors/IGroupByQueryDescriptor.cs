using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IGroupByQueryDescriptor : IAggregatableQueryDescriptor
  {
    IGroupByQueryDescriptor DataSource(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> innerGroupByQueryDescriptor);

    IGroupByQueryDescriptor Having(IHavingSpec havingSpec);

    IGroupByQueryDescriptor Dimensions(params string[] dimensions);
    
    IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions);
    
    IGroupByQueryDescriptor Dimensions(params IDimensionSpec[] dimensions);
    
    IGroupByQueryDescriptor Dimensions(IEnumerable<IDimensionSpec> dimensions);

    IGroupByQueryDescriptor Limit(ILimitSpec limitSpec);

    IGroupByQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, string groupByStrategy = null, long? maxOnDiskStorage = null);
  }
}
