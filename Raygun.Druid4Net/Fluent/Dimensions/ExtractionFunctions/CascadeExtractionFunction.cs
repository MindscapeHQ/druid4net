using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class CascadeExtractionFunction : IExtractionFunction
  {
    public string Type => "cascade";

    public IEnumerable<IExtractionFunction> ExtractionFns;

    public CascadeExtractionFunction(params IExtractionFunction[] extractionFns)
    {
      ExtractionFns = extractionFns;
    }

    public CascadeExtractionFunction(IEnumerable<IExtractionFunction> extractionFns)
    {
      ExtractionFns = extractionFns;
    }
  }
}