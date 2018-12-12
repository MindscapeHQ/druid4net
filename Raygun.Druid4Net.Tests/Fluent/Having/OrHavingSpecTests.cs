using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class OrHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new OrHavingSpec();
      Assert.That(spec.Type, Is.EqualTo("or"));
    }
    
    [Test]
    public void Constructor_WithFilter_FieldsIsSet()
    {
      var filter = new OrHavingSpec(new EqualToHavingSpec("test_dimension", 1));
      Assert.That(filter.HavingSpecs.Count(), Is.EqualTo(1));
    }
  }
}