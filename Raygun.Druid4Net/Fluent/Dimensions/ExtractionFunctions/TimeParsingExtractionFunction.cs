namespace Raygun.Druid4Net
{
  public class TimeParsingExtractionFunction : IExtractionFunction
  {
    public string Type => "time";
    
    public string TimeFormat { get; }
    
    public string ResultFormat { get; }
    
    public bool Joda { get; }

    public TimeParsingExtractionFunction(string timeFormat, string resultFormat, bool joda = true)
    {
      TimeFormat = timeFormat;
      ResultFormat = resultFormat;
      Joda = joda;
    }
  }
}