using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ScanRequestData : QueryRequestData
  {
    public string QueryType => "scan";
    public IContextSpec Context { get; }
    public IEnumerable<string> Columns { get; }
    public int? Limit { get; }
    public int? BatchSize { get; }
    public string ResultFormat { get; }

    public ScanRequestData(string dataSource, IList<string> intervals, IFilterSpec filter, IContextSpec context, IEnumerable<string> columns, string resultFormat, int? limit, int? batchSize)
    {
      DataSource = dataSource;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      Columns = columns;
      Limit = limit;
      ResultFormat = resultFormat;
      BatchSize = batchSize;
    }
  }
}