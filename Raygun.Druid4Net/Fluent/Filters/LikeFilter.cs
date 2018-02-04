namespace Raygun.Druid4Net
{
  public class LikeFilter : IFilter
  {
    public string Type => "like";

    public string Dimension { get; }

    public string Pattern { get; }

    public string Escape { get; }

    public LikeFilter(string dimension, string pattern, string escape = null)
    {
      Dimension = dimension;
      Pattern = pattern;
      Escape = escape;
    }
  }
}