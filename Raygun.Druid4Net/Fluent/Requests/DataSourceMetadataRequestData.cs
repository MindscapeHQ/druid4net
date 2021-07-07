namespace Raygun.Druid4Net
{
  public class DataSourceMetadataRequestData : DatasourceQueryRequestData
  {
    public string QueryType => "dataSourceMetadata";

    public DataSourceMetadataRequestData(IDataSourceSpec dataSource)
    {
      DataSource = dataSource;
    }
  }
}
