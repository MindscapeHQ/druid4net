using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SegmentMetadataResult : List<SegmentMetadataResultItem>
  {
  }

  public class SegmentMetadataResultItem
  {
    public string Id { get; set; }
    
    public IEnumerable<string> Intervals { get; set; }
    
    public Dictionary<string, SegmentMetadataColumnDescriptor> Columns { get; set; }
    
    public Dictionary<string, SegmentMetadataAggregatorDescriptor> Aggregators { get; set; }
    
    public IGranularitySpec QueryGranularity { get; set; }
    
    public int Size { get; set; }
    
    public int NumRows { get; set; }
  }

  public class SegmentMetadataColumnDescriptor
  {
    public string Type { get; set; }
    
    public bool HasMultipleValues { get; set; }
    
    public bool HasNulls { get; set; }
    
    public int Size { get; set; }
    
    public int? Cardinality { get; set; }
    
    public string ErrorMessage { get; set; }
  }

  public class SegmentMetadataAggregatorDescriptor
  {
    public string Type { get; set; }
    
    public string Name { get; set; }
    
    public string FieldName { get; set; }
  }
}
