namespace Raygun.Druid4Net
{
  public class InsensitiveContainsQuery : ISearchFilterQuery
  {
    public string Type => "insensitive_contains";

    public string Value { get; }

    public InsensitiveContainsQuery(string value)
    {
      Value = value;
    }
  }
}
