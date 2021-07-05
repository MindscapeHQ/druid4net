using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DefaultLimitSpec : ILimitSpec
  {
    public string Type => "default";

    public long? Limit { get; }

    public long? Offset { get; }

    public IEnumerable<OrderByColumnSpec> Columns { get; }

    public DefaultLimitSpec(params OrderByColumnSpec[] orderByColumns)
      : this(null, null, orderByColumns)
    {
    }

    public DefaultLimitSpec(long? limit = null, params OrderByColumnSpec[] orderByColumns)
      : this(limit, 0, orderByColumns)
    {
    }

    public DefaultLimitSpec(long? limit = null, long? offset = null, params OrderByColumnSpec[] orderByColumns)
    {
      Limit = limit;
      Offset = offset;
      Columns = orderByColumns;
    }
  }
}
