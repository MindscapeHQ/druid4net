namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketchToString : IPostAggregationSpec
  {
    public string Type => "quantilesDoublesSketchToString";

    public string Name { get; }
    
    public IPostAggregationSpec Field { get; }
    
    public QuantilesDoublesSketchToString(string name, IPostAggregationSpec field)
    {
      Name = name;
      Field = field;
    }
  }
}