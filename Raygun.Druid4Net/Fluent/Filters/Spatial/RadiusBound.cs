namespace Raygun.Druid4Net
{
  public class RadiusBound : ISpatialBound
  {
    public string Type => "radius";

    public double[] Coords { get; }

    public double Radius { get; }

    public RadiusBound(double[] coords, double radius)
    {
      Coords = coords;
      Radius = radius;
    }
  }
}