namespace Raygun.Druid4Net
{
  public class PartialExtractionFunction : IExtractionFunction
  {
    public string Type => "partial";

    public string Expr { get; }

    public PartialExtractionFunction(string expr)
    {
      Expr = expr;
    }
  }
}