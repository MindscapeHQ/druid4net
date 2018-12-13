namespace Raygun.Druid4Net
{
  public class DefaultDimension : IDimensionSpec
  {
    public string Type => "default";

    public string Dimension;
    
    public string OutputName;
    
    public DimensionOutputType OutputType;

    public DefaultDimension(string dimension, string outputName = null, DimensionOutputType outputType = DimensionOutputType.String)
    {
      Dimension = dimension;
      OutputName = outputName ?? dimension;
      OutputType = outputType;
    }
  }
}