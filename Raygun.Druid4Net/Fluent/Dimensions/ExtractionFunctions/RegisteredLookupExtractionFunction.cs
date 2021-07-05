namespace Raygun.Druid4Net
{
  public class RegisteredLookupExtractionFunction : IExtractionFunction
  {
    public string Type => "registeredLookup";

    public string Lookup { get; }

    public bool RetainMissingValue { get; }
    
    public string ReplaceMissingValueWith { get; }
    
    public bool Injective { get; }
    
    public bool Optimize { get; }

    public RegisteredLookupExtractionFunction(string lookup, bool retainMissingValue = false, string replaceMissingValueWith = null, bool injective = false, bool optimize = true)
    {
      Lookup = lookup;
      RetainMissingValue = retainMissingValue;
      ReplaceMissingValueWith = replaceMissingValueWith;
      Injective = injective;
      Optimize = optimize;
      
      // It is illegal to set retainMissingValue = true and also specify a replaceMissingValueWith.
      if (!string.IsNullOrEmpty(replaceMissingValueWith))
      {
        RetainMissingValue = false;
      }
    }
  }
}