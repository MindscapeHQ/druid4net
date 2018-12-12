using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeseriesResult<T> : List<TimestampedResult<T>>
  {
  }
  
  public class TimestampedResult<T>
  {
    public DateTime Timestamp { get; set; }

    public T Result { get; set; }
  }
}