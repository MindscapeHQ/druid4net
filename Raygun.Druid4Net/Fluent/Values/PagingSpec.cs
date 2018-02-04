using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class PagingSpec
  {
    internal dynamic pagingIdentifiers;

    internal long threshold;

    public PagingSpec(long threshold)
    {
      this.threshold = threshold;
    }

    public PagingSpec(long threshold, dynamic pagingIdentifiers)
    {
      this.threshold = threshold;
      this.pagingIdentifiers = pagingIdentifiers;
    }
  }
}