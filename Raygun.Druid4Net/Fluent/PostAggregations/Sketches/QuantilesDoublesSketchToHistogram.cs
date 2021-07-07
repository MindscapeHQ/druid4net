using System;

namespace Raygun.Druid4Net
{
  public class QuantilesDoublesSketchToHistogram : IPostAggregationSpec
  {
    public string Type => "quantilesDoublesSketchToHistogram";

    public string Name { get; }
    
    public IPostAggregationSpec Field { get; }
    
    public double[] SplitPoints { get; }
    
    public int? NumBins { get; }

    public QuantilesDoublesSketchToHistogram(string name, IPostAggregationSpec field, double[] splitPoints = null, int? numBins = null)
    {
      if (splitPoints != null && numBins != null)
      {
        throw new ArgumentException("Either splitPoints or numBins can be specified, but not both.");
      }
      
      Name = name;
      Field = field;
      SplitPoints = splitPoints;
      NumBins = numBins;
    }
  }
}