using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.PostAggregations
{
  [TestFixture]
  public abstract class PostAggregatorTestBase
  {
    protected abstract BasePostAggregator GetPostAggregatorParams(string name, IPostAggregationSpec fieldA, IPostAggregationSpec fieldB);
    protected abstract BasePostAggregator GetPostAggregatorEnumerable(string name, IPostAggregationSpec fieldA, IPostAggregationSpec fieldB);
    protected abstract string ExpectedAggregatorType { get; }
    
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var aggregator = GetPostAggregatorParams("test", null, null);
      Assert.That(aggregator.Type, Is.EqualTo(ExpectedAggregatorType));
    }
    
    [Test]
    public void Constructor_WithNameAndFieldsParams_ValuesAreSet()
    {
      var aggA = new ConstantPostAggregator<int>("max", 100);
      var aggB = new FieldAccessPostAggregator("price", "price");
      var aggregator = GetPostAggregatorParams("test", aggA, aggB);
      Assert.That(aggregator.Name, Is.EqualTo("test"));
      Assert.That(aggregator.Fields, Contains.Item(aggA));
      Assert.That(aggregator.Fields, Contains.Item(aggB));
    }
    
    [Test]
    public void Constructor_WithNameAndFieldsEnumerable_ValuesAreSet()
    {
      var aggA = new ConstantPostAggregator<int>("max", 100);
      var aggB = new FieldAccessPostAggregator("price", "price");
      var aggregator = GetPostAggregatorEnumerable("test", aggA, aggB);
      Assert.That(aggregator.Name, Is.EqualTo("test"));
      Assert.That(aggregator.Fields, Contains.Item(aggA));
      Assert.That(aggregator.Fields, Contains.Item(aggB));
    }
  }
}