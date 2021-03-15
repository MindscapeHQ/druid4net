using System;
using System.Globalization;

namespace Raygun.Druid4Net
{
  public class Interval
  {
    public DateTime From { get; }
    public DateTime To { get; }

    public Interval(DateTime from, DateTime to)
    {
      From = from;
      To = to;
      
      if (To < From)
      {
        To = From;
      }
    }

    public static Interval Parse(string intervalString)
    {
      if (intervalString == null) throw new ArgumentNullException(nameof(intervalString));
      var formatException = new FormatException("The string could not be parsed to an Interval.");
      if (!intervalString.Contains("/")) throw formatException;
      var dates = intervalString.Split('/');
      if (dates.Length != 2) throw formatException;
      DateTime fromDate;
      DateTime toDate;
      try
      {
        fromDate = DateTime.Parse(dates[0], null, DateTimeStyles.RoundtripKind);
        toDate = DateTime.Parse(dates[1], null, DateTimeStyles.RoundtripKind);
      }
      catch
      {
        throw formatException;
      }
      return new Interval(fromDate, toDate);
    }

    public string ToInterval()
    {
      return $"{From:yyyy-MM-ddTHH:mm:ss.fffZ}/{To:yyyy-MM-ddTHH:mm:ss.fffZ}";
    }
  }
}
