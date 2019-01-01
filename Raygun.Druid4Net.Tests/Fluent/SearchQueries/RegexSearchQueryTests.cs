using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.SearchQueries
{
  [TestFixture]
  public class RegexSearchQueryTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var query = new RegexSearchQuery("\\d");
      Assert.That(query.Type, Is.EqualTo("regex"));
    }
    
    [Test]
    public void Constructor_WithParameters_ValuesAreSet()
    {
      var query = new RegexSearchQuery("\\d");
      Assert.That(query.Pattern, Is.EqualTo("\\d"));
    }
  }
}