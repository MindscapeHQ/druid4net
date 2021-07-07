using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ITimeseriesQueryDescriptor
  {
    ITimeseriesQueryDescriptor DataSource(string dataSource);
    
    ITimeseriesQueryDescriptor DataSource(IDataSourceSpec dataSource);
    
    ITimeseriesQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns);

    ITimeseriesQueryDescriptor Interval(DateTime from, DateTime to);
    
    ITimeseriesQueryDescriptor Intervals(params Interval[] intervals);
    
    ITimeseriesQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    ITimeseriesQueryDescriptor Granularity(Granularities granularity);

    ITimeseriesQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    ITimeseriesQueryDescriptor Filter(IFilterSpec filterSpec);
    
    ITimeseriesQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec);
    
    ITimeseriesQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec);

    ITimeseriesQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec);
    
    ITimeseriesQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);
    
    ITimeseriesQueryDescriptor Descending(bool descending);

    ITimeseriesQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, bool? skipEmptyBuckets = null);
    
    IDruidRequest<TimeseriesRequestData> Generate();
  }
}
