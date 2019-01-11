namespace Raygun.Druid4Net
{
  public class BucketExtractionFunction : IExtractionFunction
  {
    public string Type => "bucket";

    public int Size;
    
    public int Offset;

    public BucketExtractionFunction(int size = 1, int offset = 0)
    {
      Size = size;
      Offset = offset;
    }
  }
}