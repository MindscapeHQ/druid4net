using System;

namespace Raygun.Druid4Net
{
  public class DurationGranularity : IGranularitySpec
  {
    public string Type => "duration";

    public long Duration { get; }

    public DateTime? Origin { get; }

    public DurationGranularity(long durationMillis, DateTime? origin = null)
    {
      Duration = durationMillis;
      Origin = origin;
    }
  }
}
