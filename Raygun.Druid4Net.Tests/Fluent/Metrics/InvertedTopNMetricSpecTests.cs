using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent
{
  [TestFixture]
  public class InvertedTopNMetricSpecTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var spec = new InvertedTopNMetricSpec(new NumericTopNMetricSpec("test_metric"));
      Assert.That(spec.Type, Is.EqualTo("inverted"));
    }
    
    [Test]
    public void Constructor_WithAllValues_PropertiesAreSet()
    {
      var spec = new InvertedTopNMetricSpec(new NumericTopNMetricSpec("test_metric"));
      Assert.That(spec.Metric, Is.TypeOf<NumericTopNMetricSpec>());
    }
  }
}