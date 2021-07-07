namespace Raygun.Druid4Net
{
  public abstract class DatasourceQueryRequestData : IQueryRequest
  {
    public object DataSource { get; internal set; }
  }
}