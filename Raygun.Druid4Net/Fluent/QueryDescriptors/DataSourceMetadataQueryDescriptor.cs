namespace Raygun.Druid4Net
{
  public class DataSourceMetadataQueryDescriptor : IDataSourceMetadataQueryDescriptor
  {
    internal IDataSourceSpec DataSourceValue;
    
    public IDataSourceMetadataQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = new TableDataSource(dataSource);
      return this;
    }

    public IDataSourceMetadataQueryDescriptor DataSource(IDataSourceSpec dataSource)
    {
      DataSourceValue = dataSource;
      return this;
    }

    public IDruidRequest<DataSourceMetadataRequestData> Generate()
    {
      var request = new DataSourceMetadataRequest();
      request.Build(this);
      return request;
    }
  }
}
