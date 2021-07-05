namespace Raygun.Druid4Net
{
  public class JavaScriptExtractionFunction : IExtractionFunction
  {
    public string Type => "javascript";

    public string Function { get; }

    public bool Injective { get; }

    public JavaScriptExtractionFunction(string function, bool injective = false)
    {
      Function = function;
      Injective = injective;
    }
  }
}