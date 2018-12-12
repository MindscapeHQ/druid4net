using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class SearchFilterTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new SearchFilter("test_dimension", new ContainsQuery("test_value"));
      Assert.That(filter.Type, Is.EqualTo("search"));
    }
    
    [Test]
    public void Constructor_WithContainsQuery_PropertiesAreSet()
    {
      var filter = new SearchFilter("test_dimension", new ContainsQuery("test_value", true));
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));

      var query = (ContainsQuery) filter.Query;
      Assert.That(query.Type, Is.EqualTo("contains"));
      Assert.That(query.Value, Is.EqualTo("test_value"));
      Assert.That(query.CaseSensitive, Is.True);
    }
    
    [Test]
    public void Constructor_WithInsensitiveContainsQuery_PropertiesAreSet()
    {
      var filter = new SearchFilter("test_dimension", new InsensitiveContainsQuery("test_value"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));

      var query = (InsensitiveContainsQuery) filter.Query;
      Assert.That(query.Type, Is.EqualTo("insensitive_contains"));
      Assert.That(query.Value, Is.EqualTo("test_value"));
    }
    
    [Test]
    public void Constructor_WithFragmentQuery_PropertiesAreSet()
    {
      var filter = new SearchFilter("test_dimension", new FragmentQuery("test_value"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));

      var query = (FragmentQuery) filter.Query;
      Assert.That(query.Type, Is.EqualTo("fragment"));
      Assert.That(query.Values.Count(), Is.EqualTo(1));
      Assert.That(query.Values, Contains.Item("test_value"));
      Assert.That(query.CaseSensitive, Is.False);
    }
    
    [Test]
    public void Constructor_WithCaseSensitiveFragmentQuery_PropertiesAreSet()
    {
      var filter = new SearchFilter("test_dimension", new FragmentQuery(true, "test_value"));
      Assert.That(filter.Dimension, Is.EqualTo("test_dimension"));

      var query = (FragmentQuery) filter.Query;
      Assert.That(query.Type, Is.EqualTo("fragment"));
      Assert.That(query.Values.Count(), Is.EqualTo(1));
      Assert.That(query.Values, Contains.Item("test_value"));
      Assert.That(query.CaseSensitive, Is.True);
    }
  }
}