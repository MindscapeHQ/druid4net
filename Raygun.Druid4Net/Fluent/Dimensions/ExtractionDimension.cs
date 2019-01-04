namespace Raygun.Druid4Net
{
  public class ExtractionDimension : IDimensionSpec
  {
    public string Type => "extraction";

    public string Dimension;
    
    public string OutputName;
    
    public DimensionOutputType OutputType;

    public IExtractionFunction ExtractionFn { get; }

  }
}