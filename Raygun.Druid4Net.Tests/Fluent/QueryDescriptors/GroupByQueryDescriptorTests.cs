using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.QueryDescriptors
{
  [TestFixture]
  public class GroupByQueryDescriptorTests
  {
    [Test]
    public void DimensionsAreSet_SetsDimensionsInBody()
    {
      var request = ((GroupByQueryDescriptor) new GroupByQueryDescriptor().Dimensions("test_dim1", "test_dim2")).Generate();

      Assert.That(request.RequestData.Dimensions.Count(), Is.EqualTo(2));
      Assert.That(request.RequestData.Dimensions.Contains("test_dim1"), Is.True);
      Assert.That(request.RequestData.Dimensions.Contains("test_dim2"), Is.True);
    }
  }
}