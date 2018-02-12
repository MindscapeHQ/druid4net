
namespace Raygun.Druid4Net
{
  public class OrderByColumnSpec
  {
    public string Dimension { get; }

    public OrderByDirection Direction { get; }

    public DimensionOrder DimensionOrder;

    public OrderByColumnSpec(string dimension, OrderByDirection direction = OrderByDirection.ascending, DimensionOrder dimensionOrder = DimensionOrder.lexicographic)
    {
      Dimension = dimension;
      Direction = direction;
      DimensionOrder = dimensionOrder;
    }
  }
}