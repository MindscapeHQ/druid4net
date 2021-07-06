using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class InlineLookupExtractionFunction : IExtractionFunction
  {
    public string Type => "lookup";

    public LookupMap Lookup { get; }

    public bool RetainMissingValue { get; }
    
    public string ReplaceMissingValueWith { get; }
    
    public bool Injective { get; }
    
    public bool Optimize { get; }

    public InlineLookupExtractionFunction(IDictionary<string, string> lookupMap, bool retainMissingValue = false, string replaceMissingValueWith = null, bool injective = false, bool optimize = true)
    {
      Lookup = new LookupMap(lookupMap);
      RetainMissingValue = retainMissingValue;
      ReplaceMissingValueWith = replaceMissingValueWith;
      Injective = injective;
      Optimize = optimize;
    }
  }
}