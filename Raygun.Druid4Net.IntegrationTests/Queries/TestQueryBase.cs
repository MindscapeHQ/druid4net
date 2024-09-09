using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Raygun.Druid4Net.IntegrationTests.Queries;

public abstract class TestQueryBase
{
  private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
                                                             .SetBasePath(Directory.GetCurrentDirectory())
                                                             .AddJsonFile("appsettings.json")
                                                             .Build();

  protected readonly IDruidClient DruidClient;

  protected DateTime FromDate = new(2016, 6, 27, 0, 0, 0, DateTimeKind.Utc);
  protected DateTime ToDate = new(2016, 6, 28, 0, 0, 0, DateTimeKind.Utc);

  protected TestQueryBase()
  {
    var options = new ConfigurationOptions
    {
      JsonSerializer = new NewtonsoftSerializer(),
      QueryApiBaseAddress = new Uri(Configuration["DruidBroker:Host"])
    };

    DruidClient = new DruidClient(options);
  }
}