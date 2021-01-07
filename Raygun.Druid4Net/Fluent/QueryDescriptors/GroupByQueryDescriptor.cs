using System;
using System.Collections.Generic;
using System.Linq;

namespace Raygun.Druid4Net
{
  public class GroupByQueryDescriptor : AggregatableQueryDescriptor, IGroupByQueryDescriptor
  {
    internal IEnumerable<IDimensionSpec> DimensionsValue;

    internal ILimitSpec LimitSpecValue;

    internal IHavingSpec HavingSpecValue;

    internal GroupByContextSpec ContextValue;

    internal IGroupByQueryDescriptor InnerDataSourceValue;

    public GroupByQueryDescriptor()
    {
      ContextValue = new GroupByContextSpec();
    }

    public IGroupByQueryDescriptor Dimensions(params string[] dimensions)
    {
      DimensionsValue = dimensions.Select(d => new DefaultDimension(d));

      return this;
    }

    public IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions)
    {
      DimensionsValue = dimensions.Select(d => new DefaultDimension(d));

      return this;
    }

    public IGroupByQueryDescriptor Dimensions(params IDimensionSpec[] dimensions)
    {
      DimensionsValue = dimensions;

      return this;
    }

    public IGroupByQueryDescriptor Dimensions(IEnumerable<IDimensionSpec> dimensions)
    {
      DimensionsValue = dimensions;

      return this;
    }

    public IGroupByQueryDescriptor Limit(ILimitSpec limitSpec)
    {
      LimitSpecValue = limitSpec;

      return this;
    }

    public IGroupByQueryDescriptor DataSource(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> innerGroupByQueryDescriptor)
    {
      var qd = (GroupByQueryDescriptor)innerGroupByQueryDescriptor(new GroupByQueryDescriptor());

      InnerDataSourceValue = qd;

      return this;
    }

    public IGroupByQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns)
    {
      SetVirtualColumns(virtualColumns);
      
      return this;
    }

    public IGroupByQueryDescriptor Having(IHavingSpec havingSpec)
    {
      HavingSpecValue = havingSpec;

      return this;
    }
    
    public IGroupByQueryDescriptor Aggregations(params IAggregationSpec[] aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }
    
    public IGroupByQueryDescriptor Aggregations(IEnumerable<IAggregationSpec> aggregationsSpec)
    {
      AggregationSpecsValue = aggregationsSpec;

      return this;
    }

    public IGroupByQueryDescriptor PostAggregations(params IPostAggregationSpec[] postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }

    public IGroupByQueryDescriptor PostAggregations(IEnumerable<IPostAggregationSpec> postAggregationsSpec)
    {
      PostAggregationSpecsValue = postAggregationsSpec;

      return this;
    }
    
    public IGroupByQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      

      return this;
    }

    public IGroupByQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);

      return this;
    }

    public IGroupByQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);

      return this;
    }
    
    public IGroupByQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;

      return this;
    }

    public IGroupByQueryDescriptor Granularity(Granularities granularity)
    {
      SetGranularity(granularity);
      
      return this;
    }
    
    public IGroupByQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;

      return this;
    }

    public IGroupByQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;

      return this;
    }

    public IGroupByQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, string groupByStrategy = null, long? maxOnDiskStorage = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.GroupByStrategy = groupByStrategy;
      ContextValue.MaxOnDiskStorage = maxOnDiskStorage;

      return this;
    }

    public IDruidRequest<GroupByRequestData> Generate()
    {
      var request = new GroupByRequest();
      request.Build(this);

      return request;
    }
  }
}
