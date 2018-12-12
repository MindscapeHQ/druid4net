using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TopNResult<T> : List<TimestampedResultList<T>>
  {
  }

  public class TimestampedResultList<T>
  {
    public DateTime Timestamp { get; set; }

    public IList<T> Result { get; set; }
  }
}