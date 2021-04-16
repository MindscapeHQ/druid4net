using System;
using System.Linq;
using NUnit.Framework;
using Raygun.Druid4Net.Fluent.Filters;

namespace Raygun.Druid4Net.Tests.Fluent.Filters
{
  [TestFixture]
  public class IntervalFilterTests
  {
    private const string TestDimension = "__time";

    private static readonly Interval TestIntervalA = new Interval(DateTime.Now.Subtract(new TimeSpan(1, 0, 0)), DateTime.Now);
    
    private static readonly Interval TestIntervalB = new Interval(DateTime.Now.Subtract(new TimeSpan(2, 0, 0)), DateTime.Now);

    [Test]
    public void Constructor_TypeIsCorrect()
    {
      var filter = new IntervalFilter(TestDimension, TestIntervalA);
      Assert.That(filter.Type, Is.EqualTo("interval"));
    }
    
    [Test]
    public void Constructor_WithSingleInterval_PropertiesAreSet()
    {
      var filter = new IntervalFilter(TestDimension, TestIntervalA);
      Assert.That(filter.Dimension, Is.EqualTo(TestDimension));
      Assert.That(filter.Intervals.Count, Is.EqualTo(1));
      Assert.That(filter.Intervals[0], Is.EqualTo(TestIntervalA.ToInterval()));
    }
    
    [Test]
    public void Constructor_WithManyParameterIntervals_PropertiesAreSet()
    {
      var filter = new IntervalFilter(TestDimension, TestIntervalA, TestIntervalB);
      Assert.That(filter.Dimension, Is.EqualTo(TestDimension));
      Assert.That(filter.Intervals.Count, Is.EqualTo(2));
      Assert.That(filter.Intervals[0], Is.EqualTo(TestIntervalA.ToInterval()));
      Assert.That(filter.Intervals[1], Is.EqualTo(TestIntervalB.ToInterval()));
    }
    
    [Test]
    public void Constructor_WithManyEnumerableIntervals_PropertiesAreSet()
    {
      var filter = new IntervalFilter(TestDimension, new []{ TestIntervalA, TestIntervalB });
      Assert.That(filter.Dimension, Is.EqualTo(TestDimension));
      Assert.That(filter.Intervals.Count, Is.EqualTo(2));
      Assert.That(filter.Intervals[0], Is.EqualTo(TestIntervalA.ToInterval()));
      Assert.That(filter.Intervals[1], Is.EqualTo(TestIntervalB.ToInterval()));
    }
  }
}
