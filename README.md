# druid4net
A .NET [druid.io](http://druid.io) client written in C#

Supports .NET 4.5 and above, .NET Standard 1.6 and 2.0

## Getting started
1. Add a reference to druid4net from [Nuget](https://www.nuget.org/packages/Druid4Net) or download and reference the dll from [releases](https://github.com/MindscapeHQ/druid4net/releases)
2. Add your favorite JSON parser (if you don't already have one referenced)
3. Implement the `IJsonSerializer` interface
4. Create a `DruidClient` and start querying

## Querying
To query druid, create an instance of the `DruidClient` using code similar to the following:

```csharp
new DruidClient(new JilSerializer(), "http://localhost");
```

_Note the [JilSerializer](https://github.com/MindscapeHQ/druid4net/blob/master/Raygun.Druid4Net.IntegrationTests/JilSerializer.cs) implementation can be found in the Integration tests project along with sample queries of all support query types._ 

### Timeseries
See [druid.io Timeseries query documentation](http://druid.io/docs/latest/querying/timeseriesquery.html) for more details on this type of query.

The following example query is performing a timeseries query against the sample wikiticker datasource.
It filters the data where the country code is 'US' and the data timestamp is within the specified date interval.
It then returns the total pages added by hour in a descending order.

```csharp
var response = _druidClient.Timeseries<TimeseriesResult<QueryResult>>(q => q
  .Descending(true)
  .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Added))
  .Filter(new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US"))
  .DataSource(Wikiticker.DataSource)
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.Hour)
);
```

### TopN
See [druid.io TopN query documentation](http://druid.io/docs/latest/querying/topnquery.html) for more details on this type of query.

The following example query is performing a topN query against the sample wikiticker datasource.
It filters the data where the country code is 'US' and the user was anonymous and the data timestamp is within the specified date interval.
It then returns the top 5 pages by count.

```csharp
var response = _druidClient.TopN<TopNResult<QueryResult>>(q => q
  .Metric(Wikiticker.Metrics.Count)
  .Dimension(Wikiticker.Dimensions.Page)
  .Threshold(5)
  .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Count))
  .Filter(new AndFilter(
    new SelectorFilter(Wikiticker.Dimensions.IsAnonymous, "true"),
    new SelectorFilter(Wikiticker.Dimensions.CountryCode, "US")
  ))
  .DataSource(Wikiticker.DataSource)
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.All)
);
```

### GroupBy
See [druid.io GroupBy query documentation](http://druid.io/docs/latest/querying/groupbyquery.html) for more details on this type of query.

The following example query is performing a groupBy query against the sample wikiticker datasource.
It returns the sum of page count grouped by Country name, then by city name and finally by page name.

```csharp
var response = _druidClient.GroupBy<GroupByResult<QueryResult>>(q => q
  .Dimensions(Wikiticker.Dimensions.CountryName, Wikiticker.Dimensions.CityName, Wikiticker.Dimensions.Page)
  .Aggregations(new LongSumAggregator(Wikiticker.Metrics.Count))
  .DataSource(Wikiticker.DataSource)
  .Interval(FromDate, ToDate)
  .Granularity(Granularities.All)
);
```

### Select
See [druid.io Select query documentation](http://druid.io/docs/latest/querying/select-query.html) for more details on this type of query.

The following example query is performing a select query against the sample wikiticker datasource.
It selects the country name, city name, page, added and deleted values, filtered to anonymous users and limited to 10 records.

```csharp
var response = _druidClient.Select<SelectResult<QueryResult>>(q => q
  .Dimensions(Wikiticker.Dimensions.CountryName, Wikiticker.Dimensions.CityName, Wikiticker.Dimensions.Page)
  .Metrics(Wikiticker.Metrics.Added, Wikiticker.Metrics.Deleted)
  .Paging(new PagingSpec(10))
  .Filter(new SelectorFilter(Wikiticker.Dimensions.IsAnonymous, "true"))
  .DataSource(Wikiticker.DataSource)
  .Interval(FromDate, ToDate)
);
```

## Notes

### Why do I need to implement IJsonSerializer?
The short answer is we wanted no dependencies. We also didn't want to implement
out own JSON serialization as there are already so many good libraries
out there that do this. Most projects already have a library included in their
solution that can be used by implementing the interface in a simple pass-through class.

### Not supported yet
* Union data source
* Time boundary queries
* Search queries
* Scan queries
* JavaScript aggregator
* Cardinality aggregator
* HyperUnique aggregator
* Filtered aggregator
* Extraction filter
* Interval filter
* Extraction dimensions
* Constant post aggregator
* Greatest/Least post aggregator
* JavaScript post aggregator
* HyperUnique cardinality post aggregator