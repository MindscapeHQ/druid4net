namespace Raygun.Druid4Net
{
  public class DimensionTopNMetricSpec : ITopNMetricSpec
  {
    public string Type => "dimension";

    public SortingOrder Ordering;
    
    public string PreviousStop;

    public DimensionTopNMetricSpec(SortingOrder ordering = SortingOrder.lexicographic, string previousStop = null)
    {
      Ordering = ordering;
      PreviousStop = previousStop;
    }
  }
}