using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Having
{
  [TestFixture]
  public class NotHavingSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new NotHavingSpec(new EqualToHavingSpec("test_dimension", 1));
      Assert.That(spec.Type, Is.EqualTo("not"));
    }
    
    [Test]
    public void Constructor_WithFilter_FieldsIsSet()
    {
      var filter = new NotHavingSpec(new EqualToHavingSpec("test_dimension", 1));
      Assert.That(filter.HavingSpec, Is.Not.Null);
      Assert.That(filter.HavingSpec, Is.TypeOf<EqualToHavingSpec>());
    }
  }
}