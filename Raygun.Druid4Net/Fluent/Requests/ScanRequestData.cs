using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ScanRequestData : QueryRequestData
  {
    public string QueryType => "scan";
    public IContextSpec Context { get; }
    public IEnumerable<string> Columns { get; }
    public int? Limit { get; }
    public OrderByDirection? Order { get; }
    public int? BatchSize { get; }
    public string ResultFormat { get; }

    public ScanRequestData(string dataSource, IList<string> intervals, IFilterSpec filter, IContextSpec context,
        IEnumerable<string> columns, string resultFormat, int? limit, OrderByDirection? order, int? batchSize)
    {
      DataSource = dataSource;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Columns = columns;
      Limit = limit;
      Order = order;
      ResultFormat = resultFormat;
      BatchSize = batchSize;
    }
  }
}