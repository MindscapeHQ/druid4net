namespace Raygun.Druid4Net
{
  internal class DataSourceMetadataRequest : IDruidRequest<DataSourceMetadataRequestData>
  {
    public DataSourceMetadataRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : IDataSourceMetadataQueryDescriptor
    {
      var qd = queryDescriptor as DataSourceMetadataQueryDescriptor;

      RequestData = new DataSourceMetadataRequestData(qd.DataSourceValue);
    }
  }
}
