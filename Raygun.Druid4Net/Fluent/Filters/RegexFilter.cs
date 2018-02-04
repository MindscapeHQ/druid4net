namespace Raygun.Druid4Net
{
  public class RegexFilter : IFilter
  {
    public string Type => "regex";

    public string Dimension { get; }

    public string Pattern { get; }

    public RegexFilter(string dimension, string pattern)
    {
      Dimension = dimension;
      Pattern = pattern;
    }
  }
}