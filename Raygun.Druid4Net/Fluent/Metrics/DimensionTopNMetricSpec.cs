namespace Raygun.Druid4Net
{
  public class DimensionTopNMetricSpec : ITopNMetricSpec
  {
    public string Type => "dimension";

    public DimensionOrder Ordering;
    
    public string PreviousStop;

    public DimensionTopNMetricSpec(DimensionOrder ordering = DimensionOrder.lexicographic, string previousStop = null)
    {
      Ordering = ordering;
      PreviousStop = previousStop;
    }
  }
}