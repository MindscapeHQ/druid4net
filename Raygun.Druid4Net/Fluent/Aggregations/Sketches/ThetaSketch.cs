namespace Raygun.Druid4Net
{
  public class ThetaSketch : BaseAggregator
  {
    public override string Type => "thetaSketch";

    public bool IsInputThetaSketch { get; }
    
    public int Size { get; }
    
    public ThetaSketch(string name, string fieldName, bool isInputThetaSketch = false, int size = 16384) 
      : base(name, fieldName)
    {
      IsInputThetaSketch = isInputThetaSketch;
      Size = size;
    }
  }
}