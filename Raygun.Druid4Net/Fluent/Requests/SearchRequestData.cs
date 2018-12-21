using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SearchRequestData : QueryRequestData
  {
    public string QueryType => "search";
    public IContextSpec Context { get; }
    public IEnumerable<string> SearchDimensions { get; }
    public int Limit { get; }
    public ISearchQuerySpec Query { get; }
    public SortSpec Sort { get; }

    public SearchRequestData(string dataSource, object granularity, IList<string> intervals, IFilterSpec filter, IContextSpec context, IEnumerable<string> searchDimensions, int limit, ISearchQuerySpec query, SortSpec sort)
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