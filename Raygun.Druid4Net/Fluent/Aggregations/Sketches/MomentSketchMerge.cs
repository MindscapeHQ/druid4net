namespace Raygun.Druid4Net
{
  public class MomentSketchMerge : BaseAggregator
  {
    public override string Type => "momentSketchMerge ";
    
    public int K { get; }
    
    public bool Compress { get; }

    public MomentSketchMerge(string name, string fieldName, int k = 13, bool compress = true) 
      : base(name, fieldName)
    {
      K = k;
      Compress = compress;
    }
  }
}