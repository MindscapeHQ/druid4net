namespace Raygun.Druid4Net
{
  public class HLLSketchEstimate : IPostAggregationSpec
  {
    public string Type => "HLLSketchEstimate";

    public string Name { get; }

    public FieldAccessPostAggregator Field { get; }

    public bool Round { get; }

    public HLLSketchEstimate(string name, FieldAccessPostAggregator field, bool round = false)
    {
      Name = name;
      Field = field;
      Round = round;
    }
  }
}