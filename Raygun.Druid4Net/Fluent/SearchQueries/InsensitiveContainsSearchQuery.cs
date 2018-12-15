namespace Raygun.Druid4Net
{
  public class InsensitiveContainsSearchQuery : ISearchQuerySpec
  {
    public string Type => "insensitive_contains";

    public string Value { get; }

    public InsensitiveContainsSearchQuery(string value)
    {
      Value = value;
    }
  }
}
