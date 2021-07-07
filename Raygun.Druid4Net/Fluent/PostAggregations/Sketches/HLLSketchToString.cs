namespace Raygun.Druid4Net
{
  public class HLLSketchToString : IPostAggregationSpec
  {
    public string Type => "HLLSketchToString";

    public string Name { get; }

    public FieldAccessPostAggregator Field { get; }

    public HLLSketchToString(string name, FieldAccessPostAggregator field)
    {
      Name = name;
      Field = field;
    }
  }
}