using System.Linq;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.Sort
{
  [TestFixture]
  public class SortSpecTests
  {
    [Test]
    public void Constructor_WithDefault_TypeIsCorrect()
    {
      var spec = new SortSpec();
      Assert.That(spec.Type, Is.EqualTo(SortingOrder.lexicographic));
    }
    
    [Test]
    public void Constructor_WithSpecifiedSort_TypeIsCorrect()
    {
      var spec = new SortSpec(SortingOrder.alphanumeric);
      Assert.That(spec.Type, Is.EqualTo(SortingOrder.alphanumeric));
    }
  }
}