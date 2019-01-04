namespace Raygun.Druid4Net
{
  public class SearchQueryExtractionFunction : IExtractionFunction
  {
    public string Type => "searchQuery";

    public ISearchQuerySpec Query;

    public SearchQueryExtractionFunction(ISearchQuerySpec query)
    {
      Query = query;
    }
  }
}