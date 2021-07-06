using System;

namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketchToRank : IPostAggregationSpec
  {
    public string Type => "quantilesDoublesSketchToRank";

    public string Name { get; }
    
    public IPostAggregationSpec Field { get; }
    
    public double Value { get; }

    public QuantilesDoublesSketchToRank(string name, IPostAggregationSpec field, double value)
    {
      Name = name;
      Field = field;
      Value = value;
    }
  }
}