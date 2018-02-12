using System;

namespace Raygun.Druid4Net
{
  public class PeriodGranularity : IGranularitySpec
  {
    public string Type => "period";

    public string Period { get; }

    public string TimeZone { get; }

    public DateTime? Origin { get; }

    public PeriodGranularity(string period, string timeZone = null, DateTime? origin = null)
    {
      Period = period;
      TimeZone = timeZone;
      Origin = origin;
    }
  }
}
