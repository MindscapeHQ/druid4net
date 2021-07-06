namespace Raygun.Druid4Net
{
  public class TimeFormatExtractionFunction : IExtractionFunction
  {
    public string Type => "timeFormat";
    
    public string Format { get; }
    
    public string TimeZone { get; }
    
    public string Locale { get; }
    
    public IGranularitySpec Granularity { get; }
    
    public bool? AsMillis { get; }

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