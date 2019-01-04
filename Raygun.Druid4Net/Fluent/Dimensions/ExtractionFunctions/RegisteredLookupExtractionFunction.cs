namespace Raygun.Druid4Net
{
  public class RegisteredLookupExtractionFunction : IExtractionFunction
  {
    public string Type => "registeredLookup";

    public string Lookup;

    public bool RetainMissingValue;
    
    public string ReplaceMissingValueWith;
    
    public bool Injective;
    
    public bool Optimize;

    public RegisteredLookupExtractionFunction(string lookup, bool retainMissingValue = false, string replaceMissingValueWith = null, bool injective = false, bool optimize = true)
    {
      Lookup = lookup;
      RetainMissingValue = retainMissingValue;
      ReplaceMissingValueWith = replaceMissingValueWith;
      Injective = injective;
      Optimize = optimize;
    }
  }
}