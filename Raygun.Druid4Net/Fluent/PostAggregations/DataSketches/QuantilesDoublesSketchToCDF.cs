using System;

namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketchToCDF : IPostAggregationSpec
  {
    public string Type => "quantilesDoublesSketchToCDF";

    public string Name { get; }
    
    public IPostAggregationSpec Field { get; }
    
    public double[] SplitPoints { get; }
    
    public QuantilesDoublesSketchToCDF(string name, IPostAggregationSpec field, double[] splitPoints)
    {
      Name = name;
      Field = field;
      SplitPoints = splitPoints;
    }
  }
}