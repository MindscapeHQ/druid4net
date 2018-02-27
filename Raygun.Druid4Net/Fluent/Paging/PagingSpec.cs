using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class PagingSpec
  {
    public IDictionary<string, int> PagingIdentifiers { get; }

    public long Threshold { get; }

    public PagingSpec(long threshold)
    {
      Threshold = threshold;
    }

    public PagingSpec(long threshold, IDictionary<string, int> pagingIdentifiers)
    {
      Threshold = threshold;
      PagingIdentifiers = pagingIdentifiers;
    }
  }
}