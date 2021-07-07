namespace Raygun.Druid4Net
{
  public class DataSourceMetadataQueryDescriptor : IDataSourceMetadataQueryDescriptor
  {
    internal string DataSourceValue;
    
    public IDataSourceMetadataQueryDescriptor DataSource(string dataSource)
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
