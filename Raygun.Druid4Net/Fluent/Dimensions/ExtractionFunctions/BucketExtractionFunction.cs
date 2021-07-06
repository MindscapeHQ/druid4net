namespace Raygun.Druid4Net
{
  public class BucketExtractionFunction : IExtractionFunction
  {
    public string Type => "bucket";

    public int Size { get; }
    
    public int Offset { get; }

    public BucketExtractionFunction(int size = 1, int offset = 0)
    {
      Size = size;
      Offset = offset;
    }
  }
}