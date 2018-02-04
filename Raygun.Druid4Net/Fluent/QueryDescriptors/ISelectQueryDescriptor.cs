using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public interface ISelectQueryDescriptor : IQueryDescriptor
  {
    ISelectQueryDescriptor Metrics(IEnumerable<string> metrics);

    ISelectQueryDescriptor Dimensions(IEnumerable<string> dimensions);

    ISelectQueryDescriptor Paging(PagingSpec pagingSpec);

    ISelectQueryDescriptor Descending(bool descending);
  }
}