using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class DataSourceMetadataResult : List<DataSourceMetadataResultItem>
  {
  }

  public class DataSourceMetadataResultItem
  {
    public DateTime Timestamp { get; set; }
    
    public DataSourceMetadataResultItemResult Result { get; set; }
  }

  public class DataSourceMetadataResultItemResult
  {
    public DateTime MaxIngestedEventTime { get; set; }
  }
}
