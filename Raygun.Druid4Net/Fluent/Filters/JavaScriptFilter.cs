namespace Raygun.Druid4Net
{
  public class JavaScriptFilter : IFilterSpec
  {
    public string Type => "javascript";

    public string Dimension { get; }

    public string Function { get; }

    public JavaScriptFilter(string dimension, string function)
    {
      Dimension = dimension;
      Function = function;
    }
  }
}