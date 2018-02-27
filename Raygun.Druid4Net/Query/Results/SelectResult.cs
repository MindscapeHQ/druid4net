using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SelectResult<T>
  {
    public DateTime Timestamp { get; set; }

    public SelectEventList<T> Result { get; set; }
  }

  public class SelectEventList<T>
  {
    public IDictionary<string, int> PagingIdentifiers { get; set; }

    public IList<SelectEvent<T>> Events { get; set; }
  }

  public class SelectEvent<T>
  {
    public string SegmentId { get; set; }

    public int Offset { get; set; }

    public T Event { get; set; }
  }
}