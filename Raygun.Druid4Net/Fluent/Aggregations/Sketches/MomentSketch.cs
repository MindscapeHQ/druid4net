namespace Raygun.Druid4Net
{
  public class MomentSketch : BaseAggregator
  {
    public override string Type => "momentSketch";
    
    public int K { get; }
    
    public bool Compress { get; }

    public MomentSketch(string name, string fieldName, int k = 13, bool compress = true) 
      : base(name, fieldName)
    {
      K = k;
      Compress = compress;
    }
  }
}