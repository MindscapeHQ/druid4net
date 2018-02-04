namespace Raygun.Druid4Net
{
  public class SearchFilter : IFilterSpec
  {
    public string Type => "search";

    public string Dimension { get; }

    public ISearchFilterQuery Query { get; }

    public SearchFilter(string dimension, ISearchFilterQuery query)
    {
      Dimension = dimension;
      Query = query;
    }
  }
}
