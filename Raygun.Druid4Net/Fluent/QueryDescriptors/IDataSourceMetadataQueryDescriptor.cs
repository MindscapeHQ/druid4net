namespace Raygun.Druid4Net
{
    public interface IDataSourceMetadataQueryDescriptor
    {
        IDataSourceMetadataQueryDescriptor DataSource(string dataSource);
        
        IDruidRequest<DataSourceMetadataRequestData> Generate();
    }
}
