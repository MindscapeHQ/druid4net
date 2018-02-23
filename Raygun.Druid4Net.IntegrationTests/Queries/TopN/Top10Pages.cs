using System;

namespace Raygun.Druid4Net.IntegrationTests.Queries.TopN
{
  public class Top10Pages : QueryBase
  {
    public void Execute(IDruidClient druidClient, DateTime fromDate, DateTime toDate)
    {
      var response = druidClient.TopN<dynamic>(q => q
        .Metric("pageCount")
        .Dimension("uri")
        .Threshold(10)
        .Aggregations(new LongSumAggregator("pageCount", "count"))
        .DataSource(TestDataSource)
        .Intervals(fromDate, toDate)
        .Filter(new SelectorFilter("type", "p"))
        .Granularity(Granularities.All)
      );

      var result = response.Data[0].result;
    }
  }
}