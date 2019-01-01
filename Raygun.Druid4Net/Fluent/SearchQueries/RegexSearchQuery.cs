namespace Raygun.Druid4Net
{
  public class RegexSearchQuery : ISearchQuerySpec
  {
    public string Type => "regex";

    public string Pattern { get; }

    public RegexSearchQuery(string pattern)
    {
      Pattern = pattern;
    }
  }
}