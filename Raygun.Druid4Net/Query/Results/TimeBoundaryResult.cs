using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeBoundaryResult : List<TimeBoundaryResultList>
  {
  }
  
  public class TimeBoundaryResultList
  {
    public DateTime Timestamp { get; set; }

    public List<TimeBoundaryResultItem> Result { get; set; }
  }
  
  public class TimeBoundaryResultItem
  {
    public DateTime MinTime { get; set; }
    
    public DateTime MaxTime { get; set; }
  }
}