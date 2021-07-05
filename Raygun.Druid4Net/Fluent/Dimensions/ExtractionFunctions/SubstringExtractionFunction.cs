namespace Raygun.Druid4Net
{
  public class SubstringExtractionFunction : IExtractionFunction
  {
    public string Type => "substring";

    public int Index { get; }
    
    public int? Length { get; }

    public SubstringExtractionFunction(int index, int? length = null)
    {
      Index = index;
      Length = length;
    }
  }
}