//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Raygun.Druid4Net
//{
//  public abstract class QueryDescriptor : IQueryDescriptor, ITopNQueryDescriptor
//  {
//    internal string _intervals;

//    internal string _dataSource;

//    internal string _granularity = "all";

//    internal FilterSpec _filterSpec;

//    internal IEnumerable<AggregationSpec> _aggregations;

//    internal IEnumerable<PostAggregationSpec> _postAggregations;

//    internal ContextSpec _contextSpec;

//    internal GranularitySpec _granularitySpec;

//    protected QueryDescriptor()
//    {
//      _contextSpec = new ContextSpec();
//    }

//    public IQueryDescriptor Intervals(DateTime dateFrom, DateTime dateTo)
//    {
//      if (dateTo < dateFrom)
//      {
//        dateTo = dateFrom;
//      }

//      _intervals = $"{dateFrom:yyyy-MM-ddTHH:mm:ss}/{dateTo:yyyy-MM-ddTHH:mm:ss}";

//      return this;
//    }

//    public IQueryDescriptor DataSource(string dataSource)
//    {
//      _dataSource = dataSource;

//      return this;
//    }

//    public IQueryDescriptor Granularity(Granularities granularity)
//    {
//      switch (granularity)
//      {
//        case Granularities.All:
//          _granularity = "all";
//          break;
//        case Granularities.Day:
//          _granularity = "day";
//          break;
//        case Granularities.Hour:
//          _granularity = "hour";
//          break;
//        case Granularities.FifteenMinute:
//          _granularity = "fifteen_minute";
//          break;
//        case Granularities.Second:
//          _granularity = "second";
//          break;
//        case Granularities.None:
//          _granularity = "none";
//          break;
//      }

//      return this;
//    }

//    public IQueryDescriptor Granularity(GranularitySpec granularitySpec)
//    {
//      _granularitySpec = granularitySpec;

//      return this;
//    }

//    public IQueryDescriptor Aggregations(IEnumerable<AggregationSpec> aggregationsSpec)
//    {
//      _aggregations = aggregationsSpec;

//      return this;
//    }

//    public IQueryDescriptor PostAggregations(IEnumerable<PostAggregationSpec> postAggregationsSpec)
//    {
//      _postAggregations = postAggregationsSpec;

//      return this;
//    }

//    public IQueryDescriptor Filter(FilterSpec filterSpec)
//    {
//      _filterSpec = filterSpec;

//      return this;
//    }

//    public IQueryDescriptor Context(bool skipEmptyBuckets)
//    {
//      _contextSpec.skipEmptyBuckets = skipEmptyBuckets;

//      return this;
//    }

//    public IQueryDescriptor Context(string groupByStrategy, long maxOnDiskStorage)
//    {
//      _contextSpec.groupByStrategy = groupByStrategy;
//      _contextSpec.maxOnDiskStorage = maxOnDiskStorage;

//      return this;
//    }

//    public IQueryDescriptor Context(int timeout, int? priority = null)
//    {
//      if (timeout <= 0)
//      {
//        timeout = ContextSpec.DefaultTimeout;
//      }

//      _contextSpec.timeout = timeout;
//      _contextSpec.priority = priority;

//      return this;
//    }

//    internal abstract IDruidRequest Finalize();

//    public virtual ITopNQueryDescriptor Dimension(string dimension) { throw new NotImplementedException(); }

//    public virtual ITopNQueryDescriptor Metric(TopNMetricSpec metricSpec) { throw new NotImplementedException(); }

//    public virtual ITopNQueryDescriptor Threshold(long threshold) { throw new NotImplementedException(); }

//    public virtual ITimeseriesQueryDescriptor Descending(bool descending) { throw new NotImplementedException(); }

//    public virtual IGroupByQueryDescriptor Having(HavingSpec havingSpec) { throw new NotImplementedException(); }

//    public virtual IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions) { throw new NotImplementedException(); }

//    public virtual IGroupByQueryDescriptor Limit(LimitSpec limitSpec) { throw new NotImplementedException(); }

//    public virtual ISelectQueryDescriptor DimensionsForSelect(IEnumerable<string> dimensions) { throw new NotImplementedException(); }

//    public virtual ISelectQueryDescriptor Metrics(IEnumerable<string> metrics) { throw new NotImplementedException(); }

//    public virtual ISelectQueryDescriptor Paging(PagingSpec pagingSpec) { throw new NotImplementedException(); }

//    public virtual ISelectQueryDescriptor DescendingForSelect(bool descending) { throw new NotImplementedException(); }
//  }
//}
