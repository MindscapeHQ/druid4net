using System;

namespace Raygun.Druid4Net
{
  public class HLLSketchEstimateWithBounds : IPostAggregationSpec
  {
    public string Type => "HLLSketchEstimateWithBounds";

    public string Name { get; }

    public FieldAccessPostAggregator Field { get; }

    public int NumStdDev { get; }

    public HLLSketchEstimateWithBounds(string name, FieldAccessPostAggregator field, int numStdDev = 1)
    {
      if (numStdDev is < 1 or > 3)
      {
        throw new ArgumentException("value must be 1, 2 or 3", nameof(numStdDev));
      }
      
      Name = name;
      Field = field;
      NumStdDev = numStdDev;
    }
  }
}