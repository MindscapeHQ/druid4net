namespace Raygun.Druid4Net
{
  public class PolygonBound : ISpatialBound
  {
    public string Type => "polygon";

    public double Abscissa { get; }

    public double Ordinate { get; }

    public PolygonBound(double abscissa, double ordinate)
    {
      Abscissa = abscissa;
      Ordinate = ordinate;
    }
  }
}