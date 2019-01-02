using System.Collections.Generic;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class JavaScriptAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = new JavaScriptAggregator("test", null, null, null, null);
      Assert.That(aggregator.Type, Is.EqualTo("javascript"));
    }
    
    [Test]
    public void Constructor_WithAllValuesEnumerable_AllValuesAreSet()
    {
      var aggregator = new JavaScriptAggregator(
        "sum(log(x)*y) + 10",
        "function(current, a, b) { return current + (Math.log(a) * b); }", 
        "function(partialA, partialB) { return partialA + partialB; }",
        "function() { return 10; }",
        new List<string>() { "x", "y" });
      
      Assert.That(aggregator.Name, Is.EqualTo("sum(log(x)*y) + 10"));
      Assert.That(aggregator.FnAggregate, Is.EqualTo("function(current, a, b) { return current + (Math.log(a) * b); }"));
      Assert.That(aggregator.FnCombine, Is.EqualTo("function(partialA, partialB) { return partialA + partialB; }"));
      Assert.That(aggregator.FnReset, Is.EqualTo("function() { return 10; }"));
      Assert.That(aggregator.FieldNames, Contains.Item("x"));
      Assert.That(aggregator.FieldNames, Contains.Item("y"));
    }
    
    [Test]
    public void Constructor_WithAllValuesParams_AllValuesAreSet()
    {
      var aggregator = new JavaScriptAggregator(
        "sum(log(x)*y) + 10",
        "function(current, a, b) { return current + (Math.log(a) * b); }", 
        "function(partialA, partialB) { return partialA + partialB; }",
        "function() { return 10; }",
        "x", "y" );
      
      Assert.That(aggregator.Name, Is.EqualTo("sum(log(x)*y) + 10"));
      Assert.That(aggregator.FnAggregate, Is.EqualTo("function(current, a, b) { return current + (Math.log(a) * b); }"));
      Assert.That(aggregator.FnCombine, Is.EqualTo("function(partialA, partialB) { return partialA + partialB; }"));
      Assert.That(aggregator.FnReset, Is.EqualTo("function() { return 10; }"));
      Assert.That(aggregator.FieldNames, Contains.Item("x"));
      Assert.That(aggregator.FieldNames, Contains.Item("y"));
    }
  }
}