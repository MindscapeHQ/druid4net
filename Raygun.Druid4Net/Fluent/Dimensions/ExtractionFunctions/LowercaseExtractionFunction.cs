namespace Raygun.Druid4Net
{
  public class LowercaseExtractionFunction : IExtractionFunction
  {
    public string Type => "lower";

    public string Locale { get; }

    public LowercaseExtractionFunction(string locale = null)
    {
      Locale = locale;
    }
  }
}