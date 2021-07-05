using System;

namespace Raygun.Druid4Net.IntegrationTests.Queries
{
  public abstract class TestQueryBase
  {
    protected DateTime FromDate = new DateTime(2016, 6, 27, 0, 0, 0, DateTimeKind.Utc);
    protected DateTime ToDate = new DateTime(2016, 6, 28, 0, 0, 0, DateTimeKind.Utc);

    protected IDruidClient DruidClient;

    protected TestQueryBase()
    {
      var options = new ConfigurationOptions()
      {
        QueryApiBaseAddress = new Uri("http://localhost:8082")
      };
      DruidClient = new DruidClient(options);
    }
  }
}