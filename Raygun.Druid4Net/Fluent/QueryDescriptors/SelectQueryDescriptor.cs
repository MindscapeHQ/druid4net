using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SelectQueryDescriptor : QueryDescriptor<SelectRequestData>, ISelectQueryDescriptor
  {
    internal PagingSpec PagingSpecValue;

    internal bool DescendingValue;

    internal IEnumerable<string> MetricsValue;

    internal IEnumerable<string> DimensionsValue;

    public ISelectQueryDescriptor Metrics(IEnumerable<string> metrics)
    {
      MetricsValue = metrics;
      return this;
    }

    public ISelectQueryDescriptor Dimensions(IEnumerable<string> dimensions)
    {
      DimensionsValue = dimensions;
      return this;
    }

    public ISelectQueryDescriptor Paging(PagingSpec pagingSpec)
    {
      PagingSpecValue = pagingSpec;
      return this;
    }

    public ISelectQueryDescriptor Descending(bool descending)
    {
      DescendingValue = descending;
      return this;
    }

    internal override IDruidRequest<SelectRequestData> Generate()
    {
      var request = new SelectRequest();
      request.Build(this);

      return request;
    }
  }
}
