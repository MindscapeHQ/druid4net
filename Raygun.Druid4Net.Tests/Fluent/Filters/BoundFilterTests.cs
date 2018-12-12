using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class BoundFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new BoundFilter<int>("test_dimension", 10);
      Assert.That(filter.Type, Is.EqualTo("bound"));
    }
    
    [Test]
    public void Constructor_WithLowerValues_PropertiesAreSet()
    {
      var filter = new BoundFilter<int>("test_dimension", 10);
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension")); 
      Assert.That(filter.Lower, Is.EqualTo(10));
      Assert.That(filter.Upper, Is.Null);
      Assert.That(filter.LowerStrict, Is.False);
      Assert.That(filter.UpperStrict, Is.False);
      Assert.That(filter.Ordering, Is.EqualTo(DimensionOrder.lexicographic));
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var filter = new BoundFilter<int>("test_dimension", 5, 10, true, true, DimensionOrder.numeric);
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension")); 
      Assert.That(filter.Lower, Is.EqualTo(5));
      Assert.That(filter.Upper, Is.EqualTo(10));
      Assert.That(filter.LowerStrict, Is.True);
      Assert.That(filter.UpperStrict, Is.True);
      Assert.That(filter.Ordering, Is.EqualTo(DimensionOrder.numeric));
    }
    
    [Test]
    public void Constructor_WithAlternateTypeValues_PropertiesAreSet()
    {
      var filter = new BoundFilter<double>("test_dimension", 0.1, 0.2);
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension")); 
      Assert.That(filter.Lower, Is.EqualTo(0.1));
      Assert.That(filter.Upper, Is.EqualTo(0.2));
    }
  }
}