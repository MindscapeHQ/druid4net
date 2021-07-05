namespace Raygun.Druid4Net
{
  public class ExtractionDimension : IDimensionSpec
  {
    public string Type => "extraction";

    public string Dimension { get; }
    
    public string OutputName { get; }
    
    public DimensionOutputType OutputType { get; }

    public IExtractionFunction ExtractionFn { get; }

    public ExtractionDimension(string dimension, string outputName = null, DimensionOutputType outputType = DimensionOutputType.String, IExtractionFunction extractionFn = null)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      OutputType = outputType;
      ExtractionFn = extractionFn;
    }
  }
}