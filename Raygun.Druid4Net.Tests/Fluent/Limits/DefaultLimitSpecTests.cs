using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent
{
  [TestFixture]
  public class DefaultLimitSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var limit = new DefaultLimitSpec(10);
      Assert.That(limit.Type, Is.EqualTo("default"));
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var limit = new DefaultLimitSpec(10, 100, new OrderByColumnSpec("test_dim"));
      Assert.That(limit.Limit, Is.EqualTo(10));
      Assert.That(limit.Offset, Is.EqualTo(100));
      Assert.That(limit.Columns.Count(), Is.EqualTo(1));
      Assert.That(limit.Columns.First().Dimension, Is.EqualTo("test_dim"));
    }
    
    [Test]
    public void Constructor_WithNullValues_PropertiesAreSetAsNull()
    {
      var limit = new DefaultLimitSpec(new OrderByColumnSpec("test_dim"));
      Assert.That(limit.Limit, Is.Null);
      Assert.That(limit.Offset, Is.Null);
    }
  }
}