using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class HavingSpec
  {
    internal string type;

    internal string aggregation;

    internal double value;

    internal IEnumerable<HavingSpec> havingSpecs;

    public HavingSpec(HavingSpecTypes type, string aggregation, double value)
    {
      this.type = type.ToString();
      this.aggregation = aggregation;
      this.value = value;
    }

    public HavingSpec(HavingSpecTypes type, IEnumerable<HavingSpec> havingSpecs)
    {
      this.type = type.ToString();
      this.havingSpecs = havingSpecs;
    }
  }

  public enum HavingSpecTypes
  {
    greaterThan,

    lessThan,

    equalTo,

    and,

    or,

    not
  }
}
