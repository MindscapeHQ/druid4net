using System;

namespace Raygun.Druid4Net
{
  public interface IGranularitySpec
  {
    string Type { get; }

    DateTime? Origin { get; }
  }
}