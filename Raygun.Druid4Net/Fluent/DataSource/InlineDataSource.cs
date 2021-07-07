using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class InlineDataSource : IDataSourceSpec, ILeftJoinDataSource, IRightJoinDataSource
  {
    public string Type => "inline";

    public IEnumerable<string> ColumnNames { get; }
    public IEnumerable<IEnumerable<string>> Rows { get; }

    public InlineDataSource(IEnumerable<string> columnNames, IEnumerable<IEnumerable<string>> rows)
    {
      ColumnNames = columnNames;
      Rows = rows;
    }
  }
}