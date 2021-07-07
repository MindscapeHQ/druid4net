using System;

namespace Raygun.Druid4Net
{
  public class MomentSketchSolveQuantiles : IPostAggregationSpec
  {
    public string Type => "momentSketchSolveQuantiles";

    public string Name { get; }
    
    public FieldAccessPostAggregator Field { get; }
    
    public double[] Fractions { get; }

    public MomentSketchSolveQuantiles(string name, FieldAccessPostAggregator field, params double[] fractions)
    {
      foreach (var fraction in fractions)
      {
        if (fraction is < 0 or > 1)
        {
          throw new ArgumentException("All fractions must be a number from 0 to 1 inclusive", nameof(fractions));
        }
      }
      
      Name = name;
      Field = field;
      Fractions = fractions;
    }
  }
}