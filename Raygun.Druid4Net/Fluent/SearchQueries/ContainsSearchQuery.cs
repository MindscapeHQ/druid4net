namespace Raygun.Druid4Net
{
  public class ContainsSearchQuery : ISearchQuerySpec
  {
    public string Type => "contains";

    public string Value { get; }

    public bool Case_Sensitive { get; }

    public ContainsSearchQuery(string value, bool caseSensitive = false)
    {
      Value = value;
      Case_Sensitive = caseSensitive;
    }
  }
}
