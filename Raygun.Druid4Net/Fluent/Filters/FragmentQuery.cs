using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class FragmentQuery : ISearchFilterQuery
  {
    public string Type => "fragment";

    public IEnumerable<string> Values { get; }

    public bool CaseSensitive { get; }

    public FragmentQuery(params string[] values) : this(false, values)
    { }

    public FragmentQuery(bool caseSensitive, params string[] values)
    {
      Values = values;
      CaseSensitive = caseSensitive;
    }
    
    public FragmentQuery(IEnumerable<string> values) : this(false, values)
    { }

    public FragmentQuery(bool caseSensitive, IEnumerable<string> values)
    {
      Values = values;
      CaseSensitive = caseSensitive;
    }
  }
}
