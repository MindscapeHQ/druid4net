using System;

namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketchToQuantile : IPostAggregationSpec
  {
    public string Type => "quantilesDoublesSketchToQuantile";

    public string Name { get; }
    
    public IPostAggregationSpec Field { get; }
    
    public double Fraction { get; }

    public QuantilesDoublesSketchToQuantile(string name, IPostAggregationSpec field, double fraction)
    {
      if (fraction is < 0 or > 1)
      {
        throw new ArgumentException("Fraction must be a number from 0 to 1 inclusive", nameof(fraction));
      }
      
      Name = name;
      Field = field;
      Fraction = fraction;
    }
  }
}