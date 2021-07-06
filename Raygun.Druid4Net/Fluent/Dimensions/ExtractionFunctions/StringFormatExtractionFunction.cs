namespace Raygun.Druid4Net
{
  public class StringFormatExtractionFunction : IExtractionFunction
  {
    public string Type => "stringFormat";

    public string Format { get; }
    
    public NullHandling NullHandling { get; }

    public StringFormatExtractionFunction(string format, NullHandling nullHandling = NullHandling.nullString)
    {
      Format = format;
      NullHandling = nullHandling;
    }
  }
}