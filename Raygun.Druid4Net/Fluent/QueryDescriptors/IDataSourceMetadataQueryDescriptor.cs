namespace Raygun.Druid4Net
{
    public interface IDataSourceMetadataQueryDescriptor
    {
        IDataSourceMetadataQueryDescriptor DataSource(string dataSource);
    
        IDataSourceMetadataQueryDescriptor DataSource(IDataSourceSpec dataSource);
        
        IDruidRequest<DataSourceMetadataRequestData> Generate();
    }
}
