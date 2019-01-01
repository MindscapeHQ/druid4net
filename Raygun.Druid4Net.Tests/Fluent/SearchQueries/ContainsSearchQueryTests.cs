using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.SearchQueries
{
  [TestFixture]
  public class ContainsSearchQueryTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var query = new ContainsSearchQuery("test_value");
      Assert.That(query.Type, Is.EqualTo("contains"));
    }
    
    [Test]
    public void Constructor_WithParameters_ValuesAreSet()
    {
      var query = new ContainsSearchQuery("Test_value", true);
      Assert.That(query.Value, Is.EqualTo("Test_value"));
      Assert.That(query.Case_Sensitive, Is.True);
    }
  }
}