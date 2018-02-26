using System;
using System.Configuration;

namespace Raygun.Druid4Net.IntegrationTests.Queries
{
  public abstract class TestQueryBase
  {
    protected DateTime FromDate = DateTime.Parse("2018-02-19T10:00:00Z");
    protected DateTime ToDate = DateTime.Parse("2018-02-26T10:00:00Z");
    protected string TestDataSource = "pulsepayload_v4";

    protected IDruidClient DruidClient;

    protected TestQueryBase()
    {
      DruidClient = new DruidClient(new JilSerializer(), ConfigurationManager.AppSettings["druid.broker.host"]);
    }
  }
}