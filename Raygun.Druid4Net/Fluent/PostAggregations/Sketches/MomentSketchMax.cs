namespace Raygun.Druid4Net
{
  public class MomentSketchMax : IPostAggregationSpec
  {
    public string Type => "momentSketchMax";

    public string Name { get; }
    
    public FieldAccessPostAggregator Field { get; }
    
    public MomentSketchMax(string name, FieldAccessPostAggregator field)
    {
      Name = name;
      Field = field;
    }
  }
}