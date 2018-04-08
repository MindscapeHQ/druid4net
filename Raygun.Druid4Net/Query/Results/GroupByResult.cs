using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class GroupByResult<T> : List<TimestampedEvent<T>>
  {
  }

  public class TimestampedEvent<T>
  {
    public DateTime Timestamp { get; set; }

    public string Version { get; set; }

    public T Event { get; set; }
  }
}