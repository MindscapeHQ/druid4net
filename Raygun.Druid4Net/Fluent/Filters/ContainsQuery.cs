namespace Raygun.Druid4Net
{
  public class ContainsQuery : ISearchFilterQuery
  {
    public string Type => "contains";

    public string Value { get; }

    public bool CaseSensitive { get; }

    public ContainsQuery(string value, bool caseSensitive = false)
    {
      Value = value;
      CaseSensitive = caseSensitive;
    }
  }
}
