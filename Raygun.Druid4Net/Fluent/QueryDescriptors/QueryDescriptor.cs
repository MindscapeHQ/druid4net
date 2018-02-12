using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class QueryDescriptor<TResponse> : IQueryDescriptor where TResponse : class
  {
    internal List<string> IntervalsValue;

    internal string DataSourceValue;

    internal object GranularityValue = "all";

    internal IFilterSpec FilterValue;

    internal ContextSpec ContextValue;

    protected QueryDescriptor()
    {
      ContextValue = new ContextSpec();
      IntervalsValue = new List<string>();
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

    public IQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null)
    {
      SetCommonContextProperties(timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);

      return this;
    }

    protected void SetCommonContextProperties(int? timeout, long? maxScatterGatherBytes, int? priority, string queryId, bool? useCache, bool? populateCache, bool? bySegment, bool? finalize, string chunkPeriod, bool? serializeDateTimeAsLong, bool? serializeDateTimeAsLongInner)
    {
      ContextValue.Timeout = timeout;
      ContextValue.MaxScatterGatherBytes = maxScatterGatherBytes;
      ContextValue.Priority = priority;
      ContextValue.QueryId = queryId;
      ContextValue.UseCache = useCache;
      ContextValue.PopulateCache = populateCache;
      ContextValue.BySegment = bySegment;
      ContextValue.Finalize = finalize;
      ContextValue.ChunkPeriod = chunkPeriod;
      ContextValue.SerializeDateTimeAsLong = serializeDateTimeAsLong;
      ContextValue.SerializeDateTimeAsLongInner = serializeDateTimeAsLongInner;
    }

    internal abstract IDruidRequest<TResponse> Generate();
  }
}
