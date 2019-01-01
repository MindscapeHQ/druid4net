using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class FragmentSearchQuery : ISearchQuerySpec
  {
    public string Type => "fragment";

    public IEnumerable<string> Values { get; }

    public bool Case_Sensitive { get; }

    public FragmentSearchQuery(params string[] values) : this(false, values)
    { }

    public FragmentSearchQuery(bool caseSensitive, params string[] values)
    {
      Values = values;
      Case_Sensitive = caseSensitive;
    }
    
    public FragmentSearchQuery(IEnumerable<string> values) : this(false, values)
    { }

    public FragmentSearchQuery(bool caseSensitive, IEnumerable<string> values)
    {
      Values = values;
      Case_Sensitive = caseSensitive;
    }
  }
}
