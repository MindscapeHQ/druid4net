using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class NotFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new NotFilter(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(filter.Type, Is.EqualTo("not"));
    }
    
    [Test]
    public void Constructor_WithFilter_FieldIsSet()
    {
      var filter = new NotFilter(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(filter.Field, Is.Not.Null);
      Assert.That(filter.Field, Is.TypeOf<SelectorFilter>());
    }
  }
}