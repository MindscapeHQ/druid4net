using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class OrFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new OrFilter();
      Assert.That(filter.Type, Is.EqualTo("or"));
    }
    
    [Test]
    public void Constructor_WithFilter_FieldsIsSet()
    {
      var filter = new OrFilter(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(filter.Fields.Count(), Is.EqualTo(1));
    }
  }
}