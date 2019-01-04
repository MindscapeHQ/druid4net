namespace Raygun.Druid4Net
{
  public class TimeFormatExtractionFunction : IExtractionFunction
  {
    public string Type => "timeFormat";
    
    public string Format;
    
    public string TimeZone;
    
    public string Locale;
    
    public IGranularitySpec Granularity;
    
    public bool? AsMillis;

    public TimeFormatExtractionFunction(string format = null, string timeZone = "UTC", string locale = null, IGranularitySpec granularity = null, bool? asMillis = null)
    {
      Format = format;
      TimeZone = timeZone;
      Locale = locale;
      Granularity = granularity;
      AsMillis = asMillis;
    }
  }
}