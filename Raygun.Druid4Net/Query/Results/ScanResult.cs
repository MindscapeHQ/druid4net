using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ScanResult<T> : List<ScanResultItem<T>>
  {
  }
  
  public class ScanResultItem<T>
  {
    public string SegmentId { get; set; }

    public List<string> Columns { get; set; }
    
    public List<T> Events { get; set; }
  }
}