namespace Raygun.Druid4Net
{
  public class MomentSketchMin : IPostAggregationSpec
  {
    public string Type => "momentSketchMin";

    public string Name { get; }
    
    public FieldAccessPostAggregator Field { get; }
    
    public MomentSketchMin(string name, FieldAccessPostAggregator field)
    {
      Name = name;
      Field = field;
    }
  }
}