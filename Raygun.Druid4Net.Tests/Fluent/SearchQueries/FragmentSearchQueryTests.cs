using System.Collections.Generic;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.SearchQueries
{
  [TestFixture]
  public class FragmentSearchQueryTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var query = new FragmentSearchQuery();
      Assert.That(query.Type, Is.EqualTo("fragment"));
    }
    
    [Test]
    public void Constructor_WithParameterValues_ValuesAreSet()
    {
      var query = new FragmentSearchQuery(true, "Test_value1", "test_value2");
      Assert.That(query.Values, Contains.Item("Test_value1"));
      Assert.That(query.Values, Contains.Item("test_value2"));
      Assert.That(query.Case_Sensitive, Is.True);
    }
    
    [Test]
    public void Constructor_WithEnumerableValues_ValuesAreSet()
    {
      var query = new FragmentSearchQuery(new List<string> { "Test_value1", "test_value2" });
      Assert.That(query.Values, Contains.Item("Test_value1"));
      Assert.That(query.Values, Contains.Item("test_value2"));
      Assert.That(query.Case_Sensitive, Is.False);
    }
  }
}