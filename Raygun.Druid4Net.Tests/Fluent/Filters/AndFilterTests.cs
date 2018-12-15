using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class AndFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new AndFilter();
      Assert.That(filter.Type, Is.EqualTo("and"));
    }
    
    [Test]
    public void Constructor_WithParametersFilter_FieldsIsSet()
    {
      var filter = new AndFilter(new SelectorFilter("test_dimension", "test_value"));
      Assert.That(filter.Fields.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void Constructor_WithEnumerableFilter_FieldsIsSet()
    {
      var filter = new AndFilter(new List<IFilterSpec> {new SelectorFilter("test_dimension", "test_value")});
      Assert.That(filter.Fields.Count(), Is.EqualTo(1));
    }
  }
}