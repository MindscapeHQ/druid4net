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
    
    [Test]
    public void Parse_DeserializesStringRepresentation()
    {
      var from = new DateTime(2018, 12, 26, 9, 46, 33, DateTimeKind.Utc);
      var to = from.AddDays(1);
      var serializerInterval = new Interval(from, to);
      var serialized = serializerInterval.ToInterval();
      Assert.That(serialized, Is.EqualTo("2018-12-26T09:46:33.000Z/2018-12-27T09:46:33.000Z"));
      var deserializedInterval = Interval.Parse(serialized);
      Assert.That(deserializedInterval.From, Is.EqualTo(from));
      Assert.That(deserializedInterval.To, Is.EqualTo(to));
    }
    
    [Test]
    public void Parse_ParsesValidNonUTCISODate()
    {
      Assert.DoesNotThrow(() => Interval.Parse("2018-12-26T09:46:33.000+0000/2018-12-27T09:46:33.000-0700"));
      Assert.DoesNotThrow(() => Interval.Parse("2018-12-26T09:46:33.000+0000/2018-12-27T09:46:33.000-07:00"));
      Assert.DoesNotThrow(() => Interval.Parse("2018-12-26T09:46:33.000+0000/2018-12-27T09:46:33.000"));
      Assert.DoesNotThrow(() => Interval.Parse("2018-12-26T09:46:33.000+0000/2018-12-27T09:46:33.000000"));
    }
    
    [Test]
    public void Parse_ThrowsOnNulls()
    {
      Assert.Throws<ArgumentNullException>(() => Interval.Parse(null));
    }
    
    [Test]
    public void Parse_ThrowsOnInvalidSeparatorInput()
    {
      Assert.Throws<FormatException>(() => Interval.Parse("2018-12-26T09:46:33.000Z//2018-12-27T09:46:33.000Z"));
      Assert.Throws<FormatException>(() => Interval.Parse("2018-12-26T09:46:33.000Z-2018-12-27T09:46:33.000Z"));
      Assert.Throws<FormatException>(() => Interval.Parse("2018-12-26T09:46:33.000Z2018-12-27T09:46:33.000Z"));
      Assert.Throws<FormatException>(() => Interval.Parse("2018-12-26T09:46:33.000Z/2018-12-27T09:46:33.000Z/2018-12-28T09:46:33.000Z"));
    }
    
    [Test]
    public void Parse_ThrowsOnInvalidDateInput()
    {
      // Both incorrect
      Assert.Throws<FormatException>(() => Interval.Parse("2018/12/26T09:46:33.000Z/2018/12/27T09:46:33.000Z"));
      // From date incorrect
      Assert.Throws<FormatException>(() => Interval.Parse("18-12-26T09:46:33.000Z/2018-12-27T09:46:33.000Z"));
      // To date incorrect
      Assert.Throws<FormatException>(() => Interval.Parse("2018-12-26T09:46:33.000Z/18-12-27T09:46:33.000Z"));
    }
  }
}
