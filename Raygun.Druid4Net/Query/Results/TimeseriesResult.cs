using System;

namespace Raygun.Druid4Net
{
  public class TimeseriesResult<T>
  {
    public DateTime Timestamp { get; set; }

    public T Result { get; set; }
  }
}