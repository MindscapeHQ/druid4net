namespace Raygun.Druid4Net
{
  public class SearchQueryExtractionFunction : IExtractionFunction
  {
    public string Type => "searchQuery";

    public ISearchQuerySpec Query { get; }

    public SearchQueryExtractionFunction(ISearchQuerySpec query)
    {
      Query = query;
    }
  }
}