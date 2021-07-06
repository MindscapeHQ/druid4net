namespace Raygun.Druid4Net
{
  public class RectangularBound : ISpatialBound
  {
    public string Type => "rectangular";

    public double[] MinCoords { get; }

    public double[] MaxCoords { get; }

    public RectangularBound(double[] minCoords, double[] maxCoords)
    {
      MinCoords = minCoords;
      MaxCoords = maxCoords;
    }
  }
}