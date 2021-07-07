using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SearchRequestData : DatasourceQueryRequestData
  {
    public string QueryType => "search";
    public object Granularity { get; }
    public IList<string> Intervals { get; }
    public IFilterSpec Filter { get; }
    public SearchContextSpec Context { get; }
    public IEnumerable<string> SearchDimensions { get; }
    public int Limit { get; }
    public ISearchQuerySpec Query { get; }
    public SortSpec Sort { get; }

    public SearchRequestData(string dataSource, object granularity, IList<string> intervals, IFilterSpec filter, SearchContextSpec context, IEnumerable<string> searchDimensions, int limit, ISearchQuerySpec query, SortSpec sort)
    {
      DataSource = dataSource;
      Granularity = granularity;
      Intervals = intervals;
      Filter = filter;
      Context = context;
      SearchDimensions = searchDimensions;
      Limit = limit;
      Query = query;
      Sort = sort;
    }
  }
}