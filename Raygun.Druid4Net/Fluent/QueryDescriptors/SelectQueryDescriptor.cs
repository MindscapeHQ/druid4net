//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Raygun.Druid4Net
//{
//  public class SelectQueryDescriptor : QueryDescriptor, ISelectQueryDescriptor
//  {
//    internal string _queryType = "select";

//    internal IEnumerable<string> _dimensions;

//    internal IEnumerable<string> _metrics;

//    internal PagingSpec _pagingSpec;

//    internal bool _descending;

//    public override ISelectQueryDescriptor DimensionsForSelect(IEnumerable<string> dimensions)
//    {
//      _dimensions = dimensions;

//      return this;
//    }

//    public override ISelectQueryDescriptor Metrics(IEnumerable<string> metrics)
//    {
//      _metrics = metrics;

//      return this;
//    }

//    public override ISelectQueryDescriptor Paging(PagingSpec pagingSpec)
//    {
//      _pagingSpec = pagingSpec;

//      return this;
//    }

//    public override ISelectQueryDescriptor DescendingForSelect(bool descending)
//    {
//      _descending = descending;

//      return this;
//    }

//    internal override IDruidRequest Finalize()
//    {
//      var request = new SelectRequest();
//      request.Build(this);

//      return request;
//    }
//  }
//}
