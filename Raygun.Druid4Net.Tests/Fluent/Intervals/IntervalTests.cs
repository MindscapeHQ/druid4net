using System;
using NUnit.Framework;

namespace Raygun.Druid4Net.Tests.Fluent
{
  [TestFixture]
  public class IntervalTests
  {
    [Test]
    public void Constructor_WithValues_PropertiesAreCorrect()
    {
      var from = new DateTime(2018, 12, 26, 9, 46, 33, DateTimeKind.Utc);
      var to = from.AddDays(1);
      var interval = new Interval(from, to);
      Assert.That(interval.From, Is.EqualTo(from));
      Assert.That(interval.To, Is.EqualTo(to));
      Assert.That(interval.ToInterval(), Is.EqualTo("2018-12-26T09:46:33.000Z/2018-12-27T09:46:33.000Z"));
    }

    [Test]
    public void Constructor_WithToBeforeFrom_ToIsResetToFromDate()
    {
      var from = new DateTime(2018, 12, 26, 9, 46, 33, DateTimeKind.Utc);
      var to = from.AddHours(-1); // Make this before from date
      var interval = new Interval(from, to);
      Assert.That(interval.From, Is.EqualTo(from));
      Assert.That(interval.To, Is.EqualTo(from));
      Assert.That(interval.ToInterval(), Is.EqualTo("2018-12-26T09:46:33.000Z/2018-12-26T09:46:33.000Z"));
    }
  }
}