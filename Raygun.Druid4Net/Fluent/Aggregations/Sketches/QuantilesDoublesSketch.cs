namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketch : BaseAggregator
  {
    public override string Type => "quantilesDoublesSketch";

    public int K { get; }
    
    public QuantilesDoublesSketch(string name, string fieldName, int k = 128) 
      : base(name, fieldName)
    {
      K = k;
    }
  }
}