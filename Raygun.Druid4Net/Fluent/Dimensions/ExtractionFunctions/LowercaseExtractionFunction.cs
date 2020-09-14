namespace Raygun.Druid4Net
{
  public class LowercaseExtractionFunction : IExtractionFunction
  {
    public string Type => "lower";

    public string Locale;

    public LowercaseExtractionFunction(string locale = null)
    {
      Locale = locale;
    }
  }
}