namespace Raygun.Druid4Net
{
  public class DimensionTopNMetricSpec : ITopNMetricSpec
  {
    public string Type => "dimension";

    public SortingOrder Ordering { get; }
    
    public string PreviousStop { get; }

    public DimensionTopNMetricSpec(SortingOrder ordering = SortingOrder.lexicographic, string previousStop = null)
    {
      Ordering = ordering;
      PreviousStop = previousStop;
    }
  }
}