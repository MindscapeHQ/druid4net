using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ListFilteredDimension : IDimensionSpec
  {
    public string Type => "listFiltered";

    public IDimensionSpec Delegate { get; }
    
    public IEnumerable<string> Values { get; }
    
    public bool? IsWhitelist { get; }

    public ListFilteredDimension(IDimensionSpec @delegate, params string[] values)
    : this (@delegate, true, values)
    {
    }
    
    public ListFilteredDimension(IDimensionSpec @delegate, IEnumerable<string> values)
    : this (@delegate, true, values)
    {
    }
    
    public ListFilteredDimension(IDimensionSpec @delegate, bool? isWhitelist, params string[] values)
    {
      Delegate = @delegate;
      Values = values;
      IsWhitelist = isWhitelist;
    }
    
    public ListFilteredDimension(IDimensionSpec @delegate, bool? isWhitelist, IEnumerable<string> values)
    {
      Delegate = @delegate;
      Values = values;
      IsWhitelist = isWhitelist;
    }
  }
}