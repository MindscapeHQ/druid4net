
namespace Raygun.Druid4Net
{
  public class OrderByColumnSpec
  {
    internal string dimension;

    internal OrderByDirection direction;

    internal DimensionOrder dimensionOrder;

    public OrderByColumnSpec(string dimension, OrderByDirection direction = OrderByDirection.ascending, DimensionOrder dimensionOrder = DimensionOrder.lexicographic)
    {
      this.dimension = dimension;
      this.direction = direction;
      this.dimensionOrder = dimensionOrder;
    }
  }

  public enum OrderByDirection
  {
    ascending,

    descending
  }

  public enum DimensionOrder
  {
    lexicographic,

    alphanumeric,

    strlen,

    numeric
  }
}