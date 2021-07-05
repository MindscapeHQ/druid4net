using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class LookupDimension : IDimensionSpec
  {
    public string Type => "lookup";

    public string Dimension { get; }
    
    public string OutputName { get; }
    
    public string Name { get; }
    
    public string ReplaceMissingValueWith { get; }
    
    public bool RetainMissingValue { get; }

    public LookupMap Lookup { get; }

    public LookupDimension(string dimension, IDictionary<string, string> lookupMap, string outputName = null, string replaceMissingValueWith = null, bool retainMissingValue = false)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      ReplaceMissingValueWith = replaceMissingValueWith;
      RetainMissingValue = retainMissingValue;
      Lookup = new LookupMap(lookupMap);

      // It is illegal to set retainMissingValue = true and also specify a replaceMissingValueWith.
      if (!string.IsNullOrEmpty(replaceMissingValueWith))
      {
        RetainMissingValue = false;
      }
    }

    public LookupDimension(string dimension, string lookupName, string outputName = null)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      Name = lookupName;
    }
  }
}