using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Aggregations
{
  [TestFixture]
  public class CardinalityAggregatorTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = new CardinalityAggregator("test", new string[0]);
      Assert.That(aggregator.Type, Is.EqualTo("cardinality"));
    }
    
    [Test]
    public void Constructor_WithAllValuesAndDimensionSpecEnumerable_AllValuesAreSet()
    {
      var dim1 = new DefaultDimension("first_name");
      var dim2 = new DefaultDimension("last_name");
      var fields = new List<IDimensionSpec> { dim1, dim2 };
      var aggregator = new CardinalityAggregator("distinct_people", fields, true, false);
      
      Assert.That(aggregator.Name, Is.EqualTo("distinct_people"));
      Assert.That(aggregator.ByRow, Is.True);
      Assert.That(aggregator.Round, Is.False);
      Assert.That(aggregator.Fields, Contains.Item(dim1));
      Assert.That(aggregator.Fields, Contains.Item(dim2));
    }
    
    [Test]
    public void Constructor_WithAllValuesAndDimensionSpecParams_AllValuesAreSet()
    {
      var dim1 = new DefaultDimension("first_name");
      var dim2 = new DefaultDimension("last_name");
      var aggregator = new CardinalityAggregator("distinct_people", true, true, dim1, dim2);
      
      Assert.That(aggregator.Name, Is.EqualTo("distinct_people"));
      Assert.That(aggregator.ByRow, Is.True);
      Assert.That(aggregator.Round, Is.True);
      Assert.That(aggregator.Fields, Contains.Item(dim1));
      Assert.That(aggregator.Fields, Contains.Item(dim2));
    }
    
    [Test]
    public void Constructor_WithAllValuesAndDimensionStringEnumerable_AllValuesAreSet()
    {
      var fields = new List<string> { "first_name", "last_name" };
      var aggregator = new CardinalityAggregator("distinct_people", fields, false, false);
      
      Assert.That(aggregator.Name, Is.EqualTo("distinct_people"));
      Assert.That(aggregator.ByRow, Is.False);
      Assert.That(aggregator.Round, Is.False);
      Assert.That(aggregator.Fields.OfType<DefaultDimension>().Any(f => f.Dimension == "first_name"), Is.True);
      Assert.That(aggregator.Fields.OfType<DefaultDimension>().Any(f => f.Dimension == "last_name"), Is.True);
    }
    
    [Test]
    public void Constructor_WithAllValuesAndDimensionStringParams_AllValuesAreSet()
    {
      var aggregator = new CardinalityAggregator("distinct_people", false, true, "first_name", "last_name");
      
      Assert.That(aggregator.Name, Is.EqualTo("distinct_people"));
      Assert.That(aggregator.ByRow, Is.False);
      Assert.That(aggregator.Round, Is.True);
      Assert.That(aggregator.Fields.OfType<DefaultDimension>().Any(f => f.Dimension == "first_name"), Is.True);
      Assert.That(aggregator.Fields.OfType<DefaultDimension>().Any(f => f.Dimension == "last_name"), Is.True);
    }
  }
}