using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public class ArithmeticPostAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Divide, null);
      Assert.That(spec.Type, Is.EqualTo("arithmetic"));
    }
    
    [Test]
    public void Constructor_WithMinimumValues_PropertiesAreSet()
    {
      var fields = new List<IPostAggregationSpec> {new FieldAccessPostAggregator("loaded", "my_loaded"), new FieldAccessPostAggregator("total", "my_total") };
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Divide, fields);
      
      Assert.That(spec.Fn, Is.EqualTo("/"));
      Assert.That(spec.Name, Is.EqualTo("average"));
      Assert.That(spec.Ordering, Is.Null);
      Assert.That(spec.Fields.Count(), Is.EqualTo(2));
    }
    
    [Test]
    public void Constructor_WithParameterValues_PropertiesAreSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Divide, null, new FieldAccessPostAggregator("loaded", "my_loaded"), new FieldAccessPostAggregator("total", "my_total"));
      
      Assert.That(spec.Fn, Is.EqualTo("/"));
      Assert.That(spec.Name, Is.EqualTo("average"));
      Assert.That(spec.Ordering, Is.Null);
      Assert.That(spec.Fields.Count(), Is.EqualTo(2));
    }
    
    [Test]
    public void Constructor_WithPlusFunction_FunctionIsSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Plus, null);
      Assert.That(spec.Fn, Is.EqualTo("+"));
    }
    
    [Test]
    public void Constructor_WithMinusFunction_FunctionIsSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Minus, null);
      Assert.That(spec.Fn, Is.EqualTo("-"));
    }
    
    [Test]
    public void Constructor_WithMultiplyFunction_FunctionIsSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Multiply, null);
      Assert.That(spec.Fn, Is.EqualTo("*"));
    }
    
    [Test]
    public void Constructor_WithDivideFunction_FunctionIsSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Divide, null);
      Assert.That(spec.Fn, Is.EqualTo("/"));
    }
    
    [Test]
    public void Constructor_WithQuotientFunction_FunctionIsSet()
    {
      var spec = new ArithmeticPostAggregator("average", ArithmeticFunction.Quotient, null);
      Assert.That(spec.Fn, Is.EqualTo("quotient"));
    }
  }
}