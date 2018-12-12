using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent
{
  [TestFixture]
  public class NumericTopNMetricSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new NumericTopNMetricSpec("test_metric");
      Assert.That(spec.Type, Is.EqualTo("numeric"));
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var spec = new NumericTopNMetricSpec("test_metric");
      Assert.That(spec.Metric, Is.EqualTo("test_metric"));
    }
  }
}