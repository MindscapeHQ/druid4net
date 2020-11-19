using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DefaultLimitSpec : ILimitSpec
  {
    public string Type => "default";

    public int Limit { get; }
    
    public int Offset { get; }

    public IEnumerable<OrderByColumnSpec> Columns { get; }

    public DefaultLimitSpec(int limit, params OrderByColumnSpec[] orderByColumns)
    {
      Limit = limit;
      Offset = 0;
      Columns = orderByColumns;
    }

    public DefaultLimitSpec(int limit, int offset = 0, params OrderByColumnSpec[] orderByColumns)
    {
      Limit = limit;
      Offset = offset;
      Columns = orderByColumns;
    }
  }
}
