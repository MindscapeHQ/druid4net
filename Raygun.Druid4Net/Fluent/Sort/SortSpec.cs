namespace Raygun.Druid4Net
{
  public class SortSpec
  {
    public SortSpec() : this(SortingOrder.lexicographic)
    {
    }
    
    public SortSpec(SortingOrder sortingOrder)
    {
      Type = sortingOrder;
    }
    
    public SortingOrder Type { get; internal set; }
  }
}