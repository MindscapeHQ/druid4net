using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class GroupByQueryDescriptorTests
  {
    [Test]
    public void DefaultQuery_HasCorrectQueryType()
    {
      var request = new GroupByQueryDescriptor().Generate();

      Assert.That(request.RequestData.QueryType, Is.EqualTo("groupBy"));
    }
    
    [Test]
    public void DimensionsAreSet_SetsDimensionsInBody()
    {
      var request = ((GroupByQueryDescriptor) new GroupByQueryDescriptor()
        .Dimensions("test_dim1", "test_dim2"))
        .Generate();

      Assert.That(request.RequestData.Dimensions.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Dimensions.Contains("test_dim1"), Is.True);
      Assert.That(request.RequestData.Dimensions.Contains("test_dim2"), Is.True);
    }

    [Test]
    public void LimitIsSet_SetsLimitInBody()
    {
      var request = ((GroupByQueryDescriptor) new GroupByQueryDescriptor()
        .Limit(new DefaultLimitSpec(10, new OrderByColumnSpec("test_dim1"))))
        .Generate();

      var limit = request.RequestData.LimitSpec as DefaultLimitSpec;

      Assert.IsNotNull(limit);
      Assert.That(limit.Type, Is.EqualTo("default"));
      Assert.That(limit.Limit, Is.EqualTo(10));
      Assert.That(limit.Columns.Count(), Is.EqualTo(1));
      Assert.That(limit.Columns.First().Dimension, Is.EqualTo("test_dim1"));
    }

    [Test]
    public void HavingIsSet_SetsHavingInBody()
    {
      var request = ((GroupByQueryDescriptor) new GroupByQueryDescriptor()
        .Having(new QueryFilterHavingSpec(new SelectorFilter("test_dim1", "test_value1"))))
        .Generate();

      var having = request.RequestData.HavingSpec as QueryFilterHavingSpec;
      
      Assert.IsNotNull(having);
      Assert.That(having.Type, Is.EqualTo("filter"));
      Assert.That(having.Filter, Is.Not.Null);
    }

    [Test]
    public void DataSourceIsSet_SetsDataSourceInBody()
    {
      var request = ((GroupByQueryDescriptor) new GroupByQueryDescriptor()
        .DataSource(descriptor => descriptor.Dimensions("test_dim1", "test_dim2"))
        .Dimensions("test_dim1"))
        .Generate();

      var datasource = request.RequestData.DataSource as GroupByRequestData;
      
      Assert.IsNotNull(datasource);
      Assert.That(datasource.Dimensions.Count(), Is.EqualTo(2));
      Assert.That(datasource.Dimensions.Contains("test_dim1"), Is.True);
      Assert.That(datasource.Dimensions.Contains("test_dim2"), Is.True);

      Assert.That(request.RequestData.Dimensions.Count(), Is.EqualTo(1));
      Assert.That(request.RequestData.Dimensions.Contains("test_dim1"), Is.True);
    }

    [Test]
    public void ContextIsSet_SetsContextValuesInBody()
    {
      var request = ((GroupByQueryDescriptor)new GroupByQueryDescriptor()
        .Context(groupByStrategy: "v2", maxOnDiskStorage: 10000))
        .Generate();

      Assert.That(request.RequestData.Context.GroupByStrategy, Is.EqualTo("v2"));
      Assert.That(request.RequestData.Context.MaxOnDiskStorage, Is.EqualTo(10000));
    }
  }
}