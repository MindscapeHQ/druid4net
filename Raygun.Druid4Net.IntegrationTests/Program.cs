using System;
using Raygun.Druid4Net.IntegrationTests.Queries.TopN;

namespace Raygun.Druid4Net.IntegrationTests
{
  class Program
  {
    static void Main(string[] args)
    {
      var druidClient = new DruidClient("http://druid3.o.raygun.io");
      var dateFrom = new DateTime(2015, 09, 12);
      var dateTo = new DateTime(2015, 09, 13);

      new Top10Pages().Execute(druidClient, dateFrom, dateTo);
    }
  }
}
