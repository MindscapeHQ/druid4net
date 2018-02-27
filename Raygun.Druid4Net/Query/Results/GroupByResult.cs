using System;

namespace Raygun.Druid4Net
{
  public class GroupByResult<T>
  {
    public DateTime Timestamp { get; set; }

    public string Version { get; set; }

    public T Event { get; set; }
  }
}