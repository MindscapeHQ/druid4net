using System;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests
{
  [TestFixture]
  public class BucketExtractionFunctionTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var extractionFn = new BucketExtractionFunction();
      Assert.That(extractionFn.Type, Is.EqualTo("bucket"));
    }
    
    [Test]
    public void Constructor_WithDefaultValues_PropertiesAreSet()
    {
      var extractionFn = new BucketExtractionFunction();
      Assert.That(extractionFn.Size, Is.EqualTo(1));
      Assert.That(extractionFn.Offset, Is.EqualTo(0));
    }
    
    [Test]
    public void Constructor_WithAllValuesSpecified_PropertiesAreSet()
    {
      var extractionFn = new BucketExtractionFunction(10, 5);
      Assert.That(extractionFn.Size, Is.EqualTo(10));
      Assert.That(extractionFn.Offset, Is.EqualTo(5));
    }
  }
}