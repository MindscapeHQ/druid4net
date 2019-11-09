# druid4net
A .NET [Apache Druid](https://druid.apache.org/) client written in C#

Supports .NET 4.5 and above, .NET Standard 1.6 and 2.0

## Getting started
1. Add a reference to druid4net from [Nuget](https://www.nuget.org/packages/Druid4Net) or download and reference the dll from [releases](https://github.com/MindscapeHQ/druid4net/releases)
2. Add your favorite JSON parser (if you don't already have one referenced)
3. Implement the `IJsonSerializer` interface
4. Create a `DruidClient` and start querying

## Querying
To query druid, create an instance of the `DruidClient` using code similar to the following:

```csharp
var options = new ConfigurationOptions()
{
  JsonSerializer = new JilSerializer(),
  QueryApiBaseAddress = new Uri("http://localhost:8082")
};
new DruidClient(options);
```

_Note the [JilSerializer](https://github.com/MindscapeHQ/druid4net/blob/master/Raygun.Druid4Net.IntegrationTests/JilSerializer.cs) implementation can be found in the Integration tests project along with sample queries of all supported query types._ 

### Timeseries
See [Apache Druid Timeseries query documentation](https://druid.apache.org/docs/latest/querying/timeseriesquery.html) for more details on this type of query.

The following example query is performing a timeseries query against the sample wikiticker datasource.
It filters the data where the country code is 'US' and the data timestamp is within the specified date interval.
It then returns the total pages added by hour in a descending order.

```csharp
var response = _druidClient.Timeseries<T>(q => q
  .Descending(true)
  .Aggregations(new LongSumAggregator("totalAdded", "added"))
  .Filter(new SelectorFilter("countryIsoCode", "US"))
  .DataSource("wikiticker")
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.Hour)
);
```

### TopN
See [Apache Druid TopN query documentation](https://druid.apache.org/docs/latest/querying/topnquery.html) for more details on this type of query.

The following example query is performing a topN query against the sample wikiticker datasource.
It filters the data where the country code is 'US' and the user was anonymous and the data timestamp is within the specified date interval.
It then returns the top 5 pages by count.

```csharp
var response = _druidClient.TopN<T>(q => q
  .Metric("totalCount")
  .Dimension("page")
  .Threshold(5)
  .Aggregations(new LongSumAggregator("totalCount", "count"))
  .Filter(new AndFilter(
    new SelectorFilter("isAnonymous", "true"),
    new SelectorFilter("countryIsoCode", "US")
  ))
  .DataSource("wikiticker")
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.All)
);
```

### GroupBy
See [Apache Druid GroupBy query documentation](https://druid.apache.org/docs/latest/querying/groupbyquery.html) for more details on this type of query.

The following example query is performing a groupBy query against the sample wikiticker datasource.
It returns the sum of page count grouped by Country name, then by city name and finally by page name.

```csharp
var response = _druidClient.GroupBy<T>(q => q
  .Dimensions("countryName", "cityName", "page")
  .Aggregations(new LongSumAggregator("totalCount", "count"))
  .DataSource("wikiticker")
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.All)
);
```

### Select
See [Apache Druid Select query documentation](https://druid.apache.org/docs/latest/querying/select-query.html) for more details on this type of query.

The following example query is performing a select query against the sample wikiticker datasource.
It selects the country name, city name, page, added and deleted values, filtered to anonymous users and limited to 10 records.

```csharp
var response = _druidClient.Select<T>(q => q
  .Dimensions("countryName", "cityName", "page")
  .Metrics("added", "deleted")
  .Paging(new PagingSpec(10))
  .Filter(new SelectorFilter("isAnonymous", "true"))
  .DataSource("wikiticker")
  .Interval(FromDate, ToDate)
);
```

### Search
See [Apache Druid Search query documentation](https://druid.apache.org/docs/latest/querying/searchquery.html) for more details on this type of query.

The following example query is performing a search query against the sample wikiticker datasource.
It searches for pages that contain the term "Dragon" and returns the page dimension value limited to the top 10 records.

```csharp
var response = _druidClient.Search(q => q
  .DataSource("wikiticker")
  .Granularity(Granularities.All)
  .SearchDimensions("page")
  .Query(new ContainsSearchQuery("Dragon"))
  .Limit(10)
  .Interval(FromDate, ToDate)
);
```

### TimeBoundary
See [Apache Druid TimeBoundary query documentation](https://druid.apache.org/docs/latest/querying/timeboundaryquery.html) for more details on this type of query.

The following example query is performing a timeBoundary query against the sample wikiticker datasource.
It finds the minimum and maximum data points filtered to anonymous users.

```csharp
var response = _druidClient.TimeBoundary(q => q
  .DataSource("wikiticker")
  .Filter(new SelectorFilter("isAnonymous", "true"))
);
```

### Scan
See [Apache Druid TimeBoundary query documentation](https://druid.apache.org/docs/latest/querying/scan-query.html) for more details on this type of query.

The following example query is performing a scan query against the sample wikiticker datasource.
It returns druid records in streaming mode, filtered to anonymous users and limited to the first 10 results. 

```csharp
var response = _druidClient.Scan<T>(q => q
  .DataSource("wikiticker")
  .Interval(FromDate, ToDate)
  .Filter(new SelectorFilter("isAnonymous", "true"))
  .Limit(10)
);
```

### Async queries
All query types have both synchronous and asynchronous methods available. 

For example:

```csharp
var response = _druidClient.Timeseries<T>(q => q...);

var response = await _druidClient.TimeseriesAsync<T>(q => q...);
```

## Notes

### Why do I need to implement IJsonSerializer?
The short answer is we wanted no dependencies. We also didn't want to implement
our own JSON serialization as there are already so many good libraries
out there that do this. Most projects already have a library included in their
solution that can be used by implementing the interface in a simple pass-through class.

### Not supported yet
* Union data source
* Extraction filter
* Interval filter
* Extraction dimensions