using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ScanRequestData : VirtualColumnQueryRequestData
  {
    public string QueryType => "scan";
    public IContextSpec Context { get; }
    public IEnumerable<string> Columns { get; }
    public int? Limit { get; }
    public int? Offset { get; }
    public OrderByDirection? Order { get; }
    public int? BatchSize { get; }
    public string ResultFormat { get; }

    public ScanRequestData(string dataSource, IEnumerable<ExpressionVirtualColumn> virtualColumns, IList<string> intervals, IFilterSpec filter, IContextSpec context,
        IEnumerable<string> columns, string resultFormat, int? limit, int? offset, OrderByDirection? order, int? batchSize)
    {
      DataSource = dataSource;
      VirtualColumns = virtualColumns;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Columns = columns;
      Limit = limit;
      Offset = offset;
      Order = order;
      ResultFormat = resultFormat;
      BatchSize = batchSize;
    }
  }
}
