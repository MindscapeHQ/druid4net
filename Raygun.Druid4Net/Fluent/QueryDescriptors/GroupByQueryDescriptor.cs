using System;
using System.Collections.Generic;
using System.Linq;

namespace Raygun.Druid4Net
{
  public class GroupByQueryDescriptor : AggregatableQueryDescriptor<GroupByRequestData>, IGroupByQueryDescriptor
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

    public IGroupByQueryDescriptor Having(IHavingSpec havingSpec)
    {
      HavingSpecValue = havingSpec;

      return this;
    }

    public IGroupByQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, string groupByStrategy = null, long? maxOnDiskStorage = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      ContextValue.GroupByStrategy = groupByStrategy;
      ContextValue.MaxOnDiskStorage = maxOnDiskStorage;

      return this;
    }

    internal override IDruidRequest<GroupByRequestData> Generate()
    {
      var request = new GroupByRequest();
      request.Build(this);

      return request;
    }
  }
}
