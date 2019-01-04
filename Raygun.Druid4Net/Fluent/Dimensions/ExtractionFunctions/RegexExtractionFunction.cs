namespace Raygun.Druid4Net
{
  public class RegexExtractionFunction : IExtractionFunction
  {
    public string Type => "regex";

    public string Expr;

    public int Index;

    public bool ReplaceMissingValue;
    
    public string ReplaceMissingValueWith;

    public RegexExtractionFunction(string expr, int index = 1, bool replaceMissingValue = false, string replaceMissingValueWith = null)
    {
      Expr = expr;
      Index = index;
      ReplaceMissingValue = replaceMissingValue;
      ReplaceMissingValueWith = replaceMissingValueWith;
    }
  }
}