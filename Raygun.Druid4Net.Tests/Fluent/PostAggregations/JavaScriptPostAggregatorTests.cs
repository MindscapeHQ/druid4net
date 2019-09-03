using System.Collections.Generic;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class JavaScriptPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new JavaScriptPostAggregator("absPercent", "");
      Assert.That(spec.Type, Is.EqualTo("javascript"));
    }
    
    [Test]
    public void Constructor_WithEnumerableFields_PropertiesAreSet()
    {
      var fields = new List<string> {"delta", "total"};
      var spec = new JavaScriptPostAggregator("absPercent", "function(delta, total) { return 100 * Math.abs(delta) / total; }", fields);
      Assert.That(spec.Name, Is.EqualTo("absPercent"));
      Assert.That(spec.Function, Is.EqualTo("function(delta, total) { return 100 * Math.abs(delta) / total; }"));
      Assert.That(spec.FieldNames, Contains.Item("delta"));
      Assert.That(spec.FieldNames, Contains.Item("total"));
    }
    
    [Test]
    public void Constructor_WithParameterFields_PropertiesAreSet()
    {
      var spec = new JavaScriptPostAggregator("absPercent", "function(delta, total) { return 100 * Math.abs(delta) / total; }", "delta", "total");
      Assert.That(spec.Name, Is.EqualTo("absPercent"));
      Assert.That(spec.Function, Is.EqualTo("function(delta, total) { return 100 * Math.abs(delta) / total; }"));
      Assert.That(spec.FieldNames, Contains.Item("delta"));
      Assert.That(spec.FieldNames, Contains.Item("total"));
    }
  }
}