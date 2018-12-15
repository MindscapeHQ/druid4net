
namespace Raygun.Druid4Net
{
  public class OrderByColumnSpec
  {
    public string Dimension { get; }

    public OrderByDirection Direction { get; }

    public SortingOrder DimensionOrder;

    public OrderByColumnSpec(string dimension, OrderByDirection direction = OrderByDirection.ascending, SortingOrder dimensionOrder = SortingOrder.lexicographic)
    {
      Dimension = dimension;
      Direction = direction;
      DimensionOrder = dimensionOrder;
    }
  }
}