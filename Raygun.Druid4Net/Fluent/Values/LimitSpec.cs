using System;
using System.Collections.Generic;
using System.Linq;

namespace Raygun.Druid4Net
{
  public class LimitSpec
  {
    internal string type;

    internal int limit;

    internal IEnumerable<OrderByColumnSpec> columns;

    public LimitSpec(int limit, params OrderByColumnSpec[] orderByColumns)
    {
      this.type = "default";
      this.limit = limit;
      this.columns = orderByColumns;
    }
  }
}
