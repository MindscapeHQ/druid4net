
namespace Raygun.Druid4Net
{
  public class BoundFilter<T> : IFilterSpec where T : struct
  {
    public string Type => "bound";

    public string Dimension { get; }

    public T? Lower { get; }

    public T? Upper { get; }

    public bool LowerStrict { get; }

    public bool UpperStrict { get; }

    public DimensionOrder Ordering { get; }

    public BoundFilter(string dimension, T? lower, T? upper = null, bool lowerStrict = false, bool upperStrict = false, DimensionOrder ordering = DimensionOrder.lexicographic)
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