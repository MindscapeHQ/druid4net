using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DefaultLimitSpec : ILimitSpec
  {
    public string Type => "default";

    public int Limit { get; }

    public IEnumerable<OrderByColumnSpec> Columns { get; }

    public DefaultLimitSpec(int limit, params OrderByColumnSpec[] orderByColumns)
    {
      Limit = limit;
      Columns = orderByColumns;
    }
  }
}
