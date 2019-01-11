namespace Raygun.Druid4Net
{
  public class ExtractionDimension : IDimensionSpec
  {
    public string Type => "extraction";

    public string Dimension;
    
    public string OutputName;
    
    public DimensionOutputType OutputType;

    public IExtractionFunction ExtractionFn;

    public ExtractionDimension(string dimension, string outputName = null, DimensionOutputType outputType = DimensionOutputType.String, IExtractionFunction extractionFn = null)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      OutputType = outputType;
      ExtractionFn = extractionFn;
    }
  }
}