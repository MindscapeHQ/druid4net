using NUnit.Framework;

namespace Raygun.Druid4Net.Tests
{
  [TestFixture]
  public class ExtractionDimensionTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var dimension = new ExtractionDimension("test");
      Assert.That(dimension.Type, Is.EqualTo("extraction"));
    }
    
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var dimension = new ExtractionDimension("test");
      Assert.That(dimension.Dimension, Is.EqualTo("test"));
      Assert.That(dimension.OutputName, Is.EqualTo("test"));
      Assert.That(dimension.OutputType, Is.EqualTo(DimensionOutputType.String));
      Assert.That(dimension.ExtractionFn, Is.Null);
    }
    
    [Test]
    public void Constructor_WithAllValuesSpecified_PropertiesAreSet()
    {
      var dimension = new ExtractionDimension("test", "test_output", DimensionOutputType.Long, new StrlenExtractionFunction());
      Assert.That(dimension.Dimension, Is.EqualTo("test"));
      Assert.That(dimension.OutputName, Is.EqualTo("test_output"));
      Assert.That(dimension.OutputType, Is.EqualTo(DimensionOutputType.Long));
      Assert.That(dimension.ExtractionFn, Is.TypeOf<StrlenExtractionFunction>());
    }
  }
}