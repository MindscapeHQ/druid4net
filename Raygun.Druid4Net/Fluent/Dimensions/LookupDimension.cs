using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class LookupDimension : IDimensionSpec
  {
    public string Type => "lookup";

    public string Dimension;
    
    public string OutputName;
    
    public string Name;
    
    public string ReplaceMissingValueWith;
    
    public bool RetainMissingValue;

    public LookupMap Lookup;

    public LookupDimension(string dimension, IDictionary<string, string> lookupMap, string outputName = null, string replaceMissingValueWith = null, bool retainMissingValue = false)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      ReplaceMissingValueWith = replaceMissingValueWith;
      RetainMissingValue = retainMissingValue;
      Lookup = new LookupMap(lookupMap);
    }

    public LookupDimension(string dimension, string lookupName, string outputName = null)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      Name = lookupName;
    }
  }
}