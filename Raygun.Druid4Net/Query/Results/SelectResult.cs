using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SelectResult<T> : List<SelectResultList<T>>
  {
  }
  
  public class SelectResultList<T>
  {
    public DateTime Timestamp { get; set; }

    public SelectEventList<T> Result { get; set; }
  }

  public class SelectEventList<T>
  {
    public Dictionary<string, int> PagingIdentifiers { get; set; }
   
    public List<string> Dimensions { get; set; }
    
    public List<string> Metrics { get; set; }

    public List<SelectEvent<T>> Events { get; set; }
  }

  public class SelectEvent<T>
  {
    public string SegmentId { get; set; }

    public int Offset { get; set; }

    public T Event { get; set; }
  }
}