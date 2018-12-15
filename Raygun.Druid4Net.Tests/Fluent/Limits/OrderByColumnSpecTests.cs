using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent
{
  [TestFixture]
  public class OrderByColumnSpecTests
  {
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var spec = new OrderByColumnSpec("test_dim");
      Assert.That(spec.Dimension, Is.EqualTo("test_dim"));
      Assert.That(spec.Direction, Is.EqualTo(OrderByDirection.ascending));
      Assert.That(spec.DimensionOrder, Is.EqualTo(SortingOrder.lexicographic));
    }
    
    [Test]
    public void Constructor_WithSpecifiedValues_PropertiesAreSet()
    {
      var spec = new OrderByColumnSpec("test_dim", OrderByDirection.descending, SortingOrder.alphanumeric);
      Assert.That(spec.Dimension, Is.EqualTo("test_dim"));
      Assert.That(spec.Direction, Is.EqualTo(OrderByDirection.descending));
      Assert.That(spec.DimensionOrder, Is.EqualTo(SortingOrder.alphanumeric));
    }
  }
}