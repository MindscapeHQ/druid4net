namespace Raygun.Druid4Net
{
  public abstract class DatasourceQueryRequestData : IQueryRequest
  {
    public IDataSourceSpec DataSource { get; internal set; }
  }
}