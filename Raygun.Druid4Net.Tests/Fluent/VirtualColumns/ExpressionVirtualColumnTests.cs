using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent.VirtualColumns
{
  [TestFixture]
  public class ExpressionVirtualColumnTests
  {
    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var virtualColumn = new ExpressionVirtualColumn("test", "test");
      Assert.That(virtualColumn.Type, Is.EqualTo("expression"));
    }
    
    [Test]
    public void Constructor_WithoutOutputType_OutputTypeIsSet()
    {
      var virtualColumn = new ExpressionVirtualColumn("test", "test");
      Assert.That(virtualColumn.OutputType, Is.EqualTo(ExpressionOutputType.FLOAT));
    }
    
    [Test]
    public void Constructor_WithOutputType_OutputTypeIsSet()
    {
      var virtualColumn = new ExpressionVirtualColumn("test", "test", ExpressionOutputType.DOUBLE);
      Assert.That(virtualColumn.OutputType, Is.EqualTo(ExpressionOutputType.DOUBLE));
    }
    
    [Test]
    public void Constructor_WithName_NameIsSet()
    {
      var testName = "TEST_NAME";
      var virtualColumn = new ExpressionVirtualColumn(testName, "test");
      Assert.That(virtualColumn.Name, Is.EqualTo(testName));
    }
    
    [Test]
    public void Constructor_WithExpression_ExpressionIsSet()
    {
      var testExpr = "TEST_EXPR";
      var virtualColumn = new ExpressionVirtualColumn("test", testExpr);
      Assert.That(virtualColumn.Expression, Is.EqualTo(testExpr));
    }
  }
}
