namespace Raygun.Druid4Net
{
  public class RegexExtractionFunction : IExtractionFunction
  {
    public string Type => "regex";

    public string Expr { get; }

    public int Index { get; }

    public bool ReplaceMissingValue { get; }
    
    public string ReplaceMissingValueWith { get; }

    public RegexExtractionFunction(string expr, int index = 1, bool replaceMissingValue = false, string replaceMissingValueWith = null)
    {
      Expr = expr;
      Index = index;
      ReplaceMissingValue = replaceMissingValue;
      ReplaceMissingValueWith = replaceMissingValueWith;
    }
  }
}