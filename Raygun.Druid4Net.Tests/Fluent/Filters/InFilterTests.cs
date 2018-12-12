using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class InFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new InFilter<string>("test_dimension");
      Assert.That(filter.Type, Is.EqualTo("in"));
    }
    
    [Test]
    public void Constructor_WithStringValues_PropertiesAreSet()
    {
      var filter = new InFilter<string>("outlaw", "Good", "Bad", "Ugly");
      Assert.That(filter.Dimension, Is.EqualTo("outlaw"));
      Assert.That(filter.Values.Count(), Is.EqualTo(3));
      Assert.That(filter.Values, Contains.Item("Good"));
      Assert.That(filter.Values, Contains.Item("Bad"));
      Assert.That(filter.Values, Contains.Item("Ugly"));
    }
    
    [Test]
    public void Constructor_WithIntegerValues_PropertiesAreSet()
    {
      var filter = new InFilter<int>("score", 1, 2);
      Assert.That(filter.Dimension, Is.EqualTo("score"));
      Assert.That(filter.Values.Count(), Is.EqualTo(2));
      Assert.That(filter.Values, Contains.Item(1));
      Assert.That(filter.Values, Contains.Item(2));
    }
  }
}