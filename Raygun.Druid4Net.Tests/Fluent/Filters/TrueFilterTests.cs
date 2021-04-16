using NUnit.Framework;
using Raygun.Druid4Net.Fluent.Filters;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
    [TestFixture]
    public class TrueFilterTests
    {
        [Test]
        public void Constructor_TypeIsCorrect()
        {
            var filter = new TrueFilter();
            Assert.That(filter.Type, Is.EqualTo("true"));
        }
    }
}
