using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ISelectQueryDescriptor
  {
    ISelectQueryDescriptor Metrics(IEnumerable<string> metrics);

    ISelectQueryDescriptor DimensionsForSelect(IEnumerable<string> dimensions);

    ISelectQueryDescriptor Paging(PagingSpec pagingSpec);

    ISelectQueryDescriptor DescendingForSelect(bool descending);
  }
}