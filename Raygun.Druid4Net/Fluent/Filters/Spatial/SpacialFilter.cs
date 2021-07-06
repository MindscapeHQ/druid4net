namespace Raygun.Druid4Net
{
  public class SpacialFilter : IFilterSpec
  {
    public string Type => "spatial";

    public string Dimension { get; }

    public ISpatialBound Bound { get; }

    public SpacialFilter(string dimension, ISpatialBound bound)
    {
      Dimension = dimension;
      Bound = bound;
    }
  }
}