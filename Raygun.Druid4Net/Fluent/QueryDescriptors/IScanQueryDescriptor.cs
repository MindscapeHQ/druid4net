using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface IScanQueryDescriptor
  {
    IScanQueryDescriptor DataSource(string dataSource);
    
    IScanQueryDescriptor DataSource(IDataSourceSpec dataSource);
    
    IScanQueryDescriptor VirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns);

    IScanQueryDescriptor Interval(DateTime from, DateTime to);
    
    IScanQueryDescriptor Intervals(params Interval[] intervals);
    
    IScanQueryDescriptor Intervals(IEnumerable<Interval> intervals);

    IScanQueryDescriptor Filter(IFilterSpec filterSpec);

    IScanQueryDescriptor Columns(params string[] columns);
    
    IScanQueryDescriptor Columns(IEnumerable<string> columns);
    
    IScanQueryDescriptor ResultFormat(ScanResultFormat resultFormat);
    
    IScanQueryDescriptor BatchSize(int batchSize);
    
    IScanQueryDescriptor Limit(int limit);
    
    IScanQueryDescriptor Offset(int offset);

    IScanQueryDescriptor Order(OrderByDirection? order);
    
    IScanQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null);

    IDruidRequest<ScanRequestData> Generate();
  }
}
