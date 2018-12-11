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
      var limit = new DefaultLimitSpec(10, new OrderByColumnSpec("test_dim"));
      Assert.That(limit.Limit, Is.EqualTo(10));
      Assert.That(limit.Columns.Count(), Is.EqualTo(1));
    }
  }
}