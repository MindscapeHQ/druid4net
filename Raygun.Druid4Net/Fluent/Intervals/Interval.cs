using System;

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

    public string ToInterval()
    {
      return $"{From:yyyy-MM-ddTHH:mm:ssZ}/{To:yyyy-MM-ddTHH:mm:ssZ}";
    }
  }
}