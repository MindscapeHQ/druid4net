namespace Raygun.Druid4Net
{
  public class ThetaSketchToString : IPostAggregationSpec
  {
    public string Type => "thetaSketchToString";

    public string Name { get; }
    
    public IThetaSketchFieldAccessor Field { get; }

    public ThetaSketchToString(string name, IThetaSketchFieldAccessor field)
    {
      Name = name;
      Field = field;
    }
  }
}