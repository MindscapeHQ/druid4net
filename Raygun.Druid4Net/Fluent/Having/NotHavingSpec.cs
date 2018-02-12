using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class NotHavingSpec : IHavingSpec
  {
    public string Type => "not";

    public IEnumerable<IHavingSpec> HavingSpecs { get; }

    public NotHavingSpec(params IHavingSpec[] havingSpecs)
    {
      HavingSpecs = havingSpecs;
    }
  }
}