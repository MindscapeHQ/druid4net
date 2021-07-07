using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ITopNQueryDescriptor
  {
    ITopNQueryDescriptor DataSource(string dataSource);
    
    ITopNQueryDescriptor DataSource(IDataSourceSpec dataSource);
    
    ITopNQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns);

    ITopNQueryDescriptor Interval(DateTime from, DateTime to);
    
    ITopNQueryDescriptor Intervals(params Interval[] intervals);
    
    ITopNQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    ITopNQueryDescriptor Granularity(Granularities granularity);

    ITopNQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    ITopNQueryDescriptor Filter(IFilterSpec filterSpec);
    
    ITopNQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec);
    
    ITopNQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec);

    ITopNQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec);
    
    ITopNQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec);
    
    ITopNQueryDescriptor Dimension(string dimension);
    
    ITopNQueryDescriptor Dimension(IDimensionSpec dimension);

    ITopNQueryDescriptor Metric(string metric);

    ITopNQueryDescriptor Metric(ITopNMetricSpec metricSpec);

    ITopNQueryDescriptor Threshold(long threshold);

    ITopNQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, int? minTopNThreshold = null);
    
    IDruidRequest<TopNRequestData> Generate();
  }
}
