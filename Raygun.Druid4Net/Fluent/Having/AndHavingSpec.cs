using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class AndHavingSpec : IHavingSpec
  {
    public string Type => "and";

    public IEnumerable<IHavingSpec> HavingSpecs { get; }

    public AndHavingSpec(params IHavingSpec[] havingSpecs)
    {
      HavingSpecs = havingSpecs;
    }
  }
}