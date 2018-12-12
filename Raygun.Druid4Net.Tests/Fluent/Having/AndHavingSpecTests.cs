using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class AndHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new AndHavingSpec();
      Assert.That(spec.Type, Is.EqualTo("and"));
    }
    
    [Test]
    public void Constructor_WithFilter_FieldsIsSet()
    {
      var filter = new AndHavingSpec(new EqualToHavingSpec("test_dimension", 1));
      Assert.That(filter.HavingSpecs.Count(), Is.EqualTo(1));
    }
  }
}