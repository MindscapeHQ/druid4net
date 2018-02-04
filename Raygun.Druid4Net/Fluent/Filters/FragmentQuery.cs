using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class FragmentQuery : ISearchFilterQuery
  {
    public string Type => "fragment";

    public IEnumerable<string> Values { get; }

    public bool CaseSensitive { get; }

    public FragmentQuery(IEnumerable<string> values, bool caseSesitive = false)
    {
      Values = values;
      CaseSensitive = caseSesitive;
    }
  }
}
