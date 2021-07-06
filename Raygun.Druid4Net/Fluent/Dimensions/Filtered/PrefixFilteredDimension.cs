namespace Raygun.Druid4Net
{
  public class PrefixFilteredDimension : IDimensionSpec
  {
    public string Type => "prefixFiltered";

    public IDimensionSpec Delegate { get; }
    
    public string Prefix { get; }

    public PrefixFilteredDimension(IDimensionSpec @delegate, string prefix)
    {
      Delegate = @delegate;
      Prefix = prefix;
    }
  }
}