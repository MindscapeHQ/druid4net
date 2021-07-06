namespace Raygun.Druid4Net
{
  public class ThetaSketchEstimate : IPostAggregationSpec
  {
    public string Type => "thetaSketchSetOp";

    public string Name { get; }
    
    public IThetaSketchFieldAccessor Field { get; }

    public ThetaSketchEstimate(string name, IThetaSketchFieldAccessor field)
    {
      Name = name;
      Field = field;
    }
  }
}