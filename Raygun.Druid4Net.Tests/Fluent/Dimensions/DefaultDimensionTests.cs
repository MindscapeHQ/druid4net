using NUnit.Framework;

namespace Raygun.Druid4Net.Tests
{
  [TestFixture]
  public class DefaultDimensionTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var dimension = new DefaultDimension("test");
      Assert.That(dimension.Type, Is.EqualTo("default"));
    }
    
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var dimension = new DefaultDimension("test");
      Assert.That(dimension.Dimension, Is.EqualTo("test"));
      Assert.That(dimension.OutputName, Is.EqualTo("test"));
      Assert.That(dimension.OutputType, Is.EqualTo(DimensionOutputType.String));
    }
    
    [Test]
    public void Constructor_WithAllValuesSpecified_PropertiesAreSet()
    {
      var dimension = new DefaultDimension("test", "test_output", DimensionOutputType.Long);
      Assert.That(dimension.Dimension, Is.EqualTo("test"));
      Assert.That(dimension.OutputName, Is.EqualTo("test_output"));
      Assert.That(dimension.OutputType, Is.EqualTo(DimensionOutputType.Long));
    }
  }
}