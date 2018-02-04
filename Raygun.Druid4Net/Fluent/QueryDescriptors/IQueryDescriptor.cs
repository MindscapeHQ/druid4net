using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IQueryDescriptor
  {
    string QueryType { get; }

    IQueryDescriptor DataSource(string dataSource);

    IQueryDescriptor Intervals(DateTime dateFrom, DateTime dateTo);

    IQueryDescriptor Granularity(Granularities granularity);

    IQueryDescriptor Granularity(IGranularitySpec granularitySpec);

    IQueryDescriptor Filter(FilterSpec filterSpec);

    IQueryDescriptor Aggregations(IEnumerable<AggregationSpec> aggregationsSpec);

    IQueryDescriptor PostAggregations(IEnumerable<PostAggregationSpec> postAggregationsSpec);

    ITopNQueryDescriptor Dimension(string dimension);

    ITopNQueryDescriptor Metric(TopNMetricSpec metricSpec);

    ITopNQueryDescriptor Threshold(long threshold);

    ITimeseriesQueryDescriptor Descending(bool descending);

    IQueryDescriptor Context(bool skipEmptyBuckets);

    IQueryDescriptor Context(string groupByStrategy, long maxOnDiskStorage);

    IQueryDescriptor Context(int timeout, int? priority = null);

    IGroupByQueryDescriptor Having(HavingSpec havingSpec);

    IGroupByQueryDescriptor Limit(LimitSpec limitSpec);

    IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions);

    ISelectQueryDescriptor DimensionsForSelect(IEnumerable<string> dimensions);

    ISelectQueryDescriptor Metrics(IEnumerable<string> metrics);
  }
}