
namespace Raygun.Druid4Net
{
  public class BoundFilter<T> : IFilterSpec
  {
    public string Type => "bound";

    public string Dimension { get; }

    public T Lower { get; }

    public T Upper { get; }

    public bool LowerStrict { get; }

    public bool UpperStrict { get; }

    public SortingOrder Ordering { get; }

    public BoundFilter(string dimension, T lower, T upper, bool lowerStrict = false, bool upperStrict = false, SortingOrder ordering = SortingOrder.lexicographic)
    {
      Dimension = dimension;
      Lower = lower;
      Upper = upper;
      LowerStrict = lowerStrict;
      UpperStrict = upperStrict;
      Ordering = ordering;
    }
  }
}