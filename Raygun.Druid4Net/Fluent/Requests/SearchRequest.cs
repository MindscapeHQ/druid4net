namespace Raygun.Druid4Net
{
  internal class SearchRequest : IDruidRequest<SearchRequestData>
  {
    public SearchRequestData RequestData { get; private set; }

    public void Build<T>(T queryDescriptor) where T : ISearchQueryDescriptor
    {
      var qd = queryDescriptor as SearchQueryDescriptor;

      RequestData = new SearchRequestData(qd.DataSourceValue, qd.GranularityValue, qd.IntervalsValue, qd.FilterValue, qd.ContextValue, qd.SearchDimensionsValue, qd.LimitValue, qd.QueryValue, qd.SortValue);
    }
  }
}
