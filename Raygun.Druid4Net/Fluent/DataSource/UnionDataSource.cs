namespace Raygun.Druid4Net
{
  public class UnionDataSource : IDataSourceSpec
  {
    public string Type => "union";

    public string[] DataSources { get; }

    public UnionDataSource(params string[] tableDataSources)
    {
      DataSources = tableDataSources;
    }
  }
}