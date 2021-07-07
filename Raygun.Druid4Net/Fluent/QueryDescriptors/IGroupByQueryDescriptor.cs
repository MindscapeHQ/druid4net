using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IGroupByQueryDescriptor
  {
    IGroupByQueryDescriptor DataSource(string dataSource);
    
    IGroupByQueryDescriptor DataSource(IDataSourceSpec dataSource);
    
    IGroupByQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns);

    IGroupByQueryDescriptor Interval(DateTime from, DateTime to);
    
    IGroupByQueryDescriptor Intervals(params Interval[] intervals);
    
    IGroupByQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    IGroupByQueryDescriptor Granularity(Granularities granularity);

    IGroupByQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    IGroupByQueryDescriptor Filter(IFilterSpec filterSpec);
    
    IGroupByQueryDescriptor Having(IHavingSpec havingSpec);

    IGroupByQueryDescriptor Dimensions(params string[] dimensions);
    
    IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions);
    
    IGroupByQueryDescriptor Dimensions(params IDimensionSpec[] dimensions);
    
    IGroupByQueryDescriptor Dimensions(IEnumerable<IDimensionSpec> dimensions);
    
    IGroupByQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec);
    
    IGroupByQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec);

    IGroupByQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec);
    
    IGroupByQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);

    IGroupByQueryDescriptor Limit(ILimitSpec limitSpec);

    IGroupByQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, string groupByStrategy = null, long? maxOnDiskStorage = null);
    
    IDruidRequest<GroupByRequestData> Generate();
  }
}
