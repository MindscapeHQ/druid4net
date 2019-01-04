namespace Raygun.Druid4Net
{
  public class TimeParsingExtractionFunction : IExtractionFunction
  {
    public string Type => "time";
    
    public string TimeFormat;
    
    public string ResultFormat;
    
    public bool Joda;

    public TimeParsingExtractionFunction(string timeFormat, string resultFormat, bool joda = true)
    {
      TimeFormat = timeFormat;
      ResultFormat = resultFormat;
      Joda = joda;
    }
  }
}