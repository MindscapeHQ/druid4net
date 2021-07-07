namespace Raygun.Druid4Net
{
  public class TableDataSource : IDataSourceSpec, ILeftJoinDataSource
  {
    public string Type => "table";

    public string Name { get; }

    public TableDataSource(string name)
    {
      Name = name;
    }
  }
}