using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class OrHavingSpec : IHavingSpec
  {
    public string Type => "or";

    public IEnumerable<IHavingSpec> HavingSpecs { get; }

    public OrHavingSpec(params IHavingSpec[] havingSpecs)
    {
      HavingSpecs = havingSpecs;
    }
  }
}