namespace Raygun.Druid4Net
{
  public class UppercaseExtractionFunction : IExtractionFunction
  {
    public string Type => "upper";

    public string Locale { get; }

    public UppercaseExtractionFunction(string locale = null)
    {
      Locale = locale;
    }
  }
}