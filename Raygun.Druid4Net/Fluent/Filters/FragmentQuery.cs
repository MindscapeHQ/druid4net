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

    public FragmentQuery(bool caseSesitive, params string[] values)
    {
      Values = values;
      CaseSensitive = caseSesitive;
    }
  }
}
