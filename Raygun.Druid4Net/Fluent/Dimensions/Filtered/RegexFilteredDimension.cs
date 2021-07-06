namespace Raygun.Druid4Net
{
  public class RegexFilteredDimension : IDimensionSpec
  {
    public string Type => "regexFiltered";

    public IDimensionSpec Delegate { get; }
    
    public string Pattern { get; }

    public RegexFilteredDimension(IDimensionSpec @delegate, string pattern)
    {
      Delegate = @delegate;
      Pattern = pattern;
    }
  }
}