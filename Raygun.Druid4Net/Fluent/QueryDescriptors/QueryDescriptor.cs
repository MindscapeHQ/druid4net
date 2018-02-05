using System;
using System.Collections.Generic;
using Jil;

namespace Raygun.Druid4Net
{
  public abstract class QueryDescriptor<TResponse> : IQueryDescriptor where TResponse : class
  {
    internal List<string> IntervalsValue;

    internal string DataSourceValue;

    internal object GranularityValue = "all";

    //internal IGranularitySpec GranularitySpecValue;

    internal IFilterSpec FilterValue;

    internal ContextSpec ContextValue;

    protected QueryDescriptor()
    {
      ContextValue = new ContextSpec();
      IntervalsValue = new List<string>();

      JSON.SetDefaultOptions(new Options(prettyPrint: false, excludeNulls: true, includeInherited: true, serializationNameFormat: SerializationNameFormat.CamelCase));
    }

    public IQueryDescriptor Intervals(DateTime dateFrom, DateTime dateTo)
    {
      if (dateTo < dateFrom)
      {
        dateTo = dateFrom;
      }

      IntervalsValue.Add($"{dateFrom:yyyy-MM-ddTHH:mm:ssZ}/{dateTo:yyyy-MM-ddTHH:mm:ssZ}");

      return this;
    }

    public IQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;

      return this;
    }

    public IQueryDescriptor Granularity(Granularities granularity)
    {
      switch (granularity)
      {
        case Granularities.All:
          GranularityValue = "all";
          break;
        case Granularities.None:
          GranularityValue = "none";
          break;
        case Granularities.Second:
          GranularityValue = "second";
          break;
        case Granularities.Minute:
          GranularityValue = "minute";
          break;
        case Granularities.FifteenMinute:
          GranularityValue = "fifteen_minute";
          break;
        case Granularities.ThirtyMinute:
          GranularityValue = "thirty_minute";
          break;
        case Granularities.Hour:
          GranularityValue = "hour";
          break;
        case Granularities.Day:
          GranularityValue = "day";
          break;
        case Granularities.Week:
          GranularityValue = "week";
          break;
        case Granularities.Month:
          GranularityValue = "month";
          break;
        case Granularities.Quarter:
          GranularityValue = "quarter";
          break;
        case Granularities.Year:
          GranularityValue = "year";
          break;
      }

      return this;
    }

    public IQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;

      return this;
    }


    public IQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;

      return this;
    }

    //public IQueryDescriptor Context(bool skipEmptyBuckets)
    //{
    //  _contextSpec.skipEmptyBuckets = skipEmptyBuckets;

    //  return this;
    //}

    //public IQueryDescriptor Context(string groupByStrategy, long maxOnDiskStorage)
    //{
    //  _contextSpec.groupByStrategy = groupByStrategy;
    //  _contextSpec.maxOnDiskStorage = maxOnDiskStorage;

    //  return this;
    //}

    //public IQueryDescriptor Context(int timeout, int? priority = null)
    //{
    //  if (timeout <= 0)
    //  {
    //    timeout = ContextSpec.DefaultTimeout;
    //  }

    //  _contextSpec.timeout = timeout;
    //  _contextSpec.priority = priority;

    //  return this;
    //}

    internal abstract IDruidRequest<TResponse> Generate();

    //public virtual ITopNQueryDescriptor Dimension(string dimension) { throw new NotImplementedException(); }

    //public virtual ITopNQueryDescriptor Metric(TopNMetricSpec metricSpec) { throw new NotImplementedException(); }

    //public virtual ITopNQueryDescriptor Threshold(long threshold) { throw new NotImplementedException(); }

    //public virtual ITimeseriesQueryDescriptor Descending(bool descending) { throw new NotImplementedException(); }

    //public virtual IGroupByQueryDescriptor Having(HavingSpec havingSpec) { throw new NotImplementedException(); }

    //public virtual IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions) { throw new NotImplementedException(); }

    //public virtual IGroupByQueryDescriptor Limit(LimitSpec limitSpec) { throw new NotImplementedException(); }

    //public virtual ISelectQueryDescriptor DimensionsForSelect(IEnumerable<string> dimensions) { throw new NotImplementedException(); }

    //public virtual ISelectQueryDescriptor Metrics(IEnumerable<string> metrics) { throw new NotImplementedException(); }

    //public virtual ISelectQueryDescriptor Paging(PagingSpec pagingSpec) { throw new NotImplementedException(); }

    //public virtual ISelectQueryDescriptor DescendingForSelect(bool descending) { throw new NotImplementedException(); }
  }
}
