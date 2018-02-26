using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNResult<T> : List<TimestampedResult<T>>
  {
  }

  public class TimestampedResult<T>
  {
    public DateTime Timestamp { get; set; }

    public IList<T> Result { get; set; }
  }
}