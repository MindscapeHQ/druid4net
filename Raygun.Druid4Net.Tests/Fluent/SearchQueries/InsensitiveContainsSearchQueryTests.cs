using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.SearchQueries
{
  [TestFixture]
  public class InsensitiveContainsSearchQueryTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var query = new InsensitiveContainsSearchQuery("test_value");
      Assert.That(query.Type, Is.EqualTo("insensitive_contains"));
    }
    
    [Test]
    public void Constructor_WithParameters_ValuesAreSet()
    {
      var query = new InsensitiveContainsSearchQuery("Test_value");
      Assert.That(query.Value, Is.EqualTo("Test_value"));
    }
  }
}