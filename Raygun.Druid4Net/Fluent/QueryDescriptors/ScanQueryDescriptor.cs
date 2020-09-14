using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ScanQueryDescriptor : QueryDescriptor, IScanQueryDescriptor
  {
    internal int? LimitValue;

    internal OrderByDirection? OrderValue;

    internal int? BatchSizeValue;
    
    internal string ResultFormatValue;

    internal IEnumerable<string> ColumnsValue;

    internal ContextSpec ContextValue;

    public ScanQueryDescriptor()
    {
      ContextValue = new ContextSpec();
      ResultFormatValue = "list";
    }

    public IScanQueryDescriptor Columns(params string[] columns)
    {
      ColumnsValue = columns;
      return this;
    }

    public IScanQueryDescriptor Columns(IEnumerable<string> columns)
    {
      ColumnsValue = columns;
      return this;
    }

    public IScanQueryDescriptor BatchSize(int batchSize)
    {
      BatchSizeValue = batchSize;
      return this;
    }

    public IScanQueryDescriptor Limit(int limit)
    {
      LimitValue = limit;
      return this;
    }

    public IScanQueryDescriptor Order(OrderByDirection? order)
    {
      OrderValue = order;
      return this;
    }

    public IScanQueryDescriptor ResultFormat(ScanResultFormat resultFormat)
    {
      switch (resultFormat)
      {
        case ScanResultFormat.List:
          ResultFormatValue = "list";
          break;
        case ScanResultFormat.CompactedList:
          ResultFormatValue = "compactedList";
          break;
      }
      return this;
    }
    
    public IScanQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      
      return this;
    }

    public IScanQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);
      return this;
    }

    public IScanQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);
      return this;
    }
    
    public IScanQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;
      return this;
    }

    public IScanQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;
      return this;
    }
    
    public IScanQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner);
      return this;
    }

    public IDruidRequest<ScanRequestData> Generate()
    {
      var request = new ScanRequest();
      request.Build(this);
      return request;
    }
  }
}
