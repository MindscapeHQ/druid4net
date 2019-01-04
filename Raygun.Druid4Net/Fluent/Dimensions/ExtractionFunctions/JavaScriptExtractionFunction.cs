namespace Raygun.Druid4Net
{
  public class JavaScriptExtractionFunction : IExtractionFunction
  {
    public string Type => "javascript";

    public string Function;

    public bool Injective;

    public JavaScriptExtractionFunction(string function, bool injective = false)
    {
      Function = function;
      Injective = injective;
    }
  }
}