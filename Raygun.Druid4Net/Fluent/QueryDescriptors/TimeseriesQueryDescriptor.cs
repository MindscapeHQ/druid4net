//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Raygun.Druid4Net
//{
//  public class TimeseriesQueryDescriptor : QueryDescriptor, ITimeseriesQueryDescriptor, IQueryDescriptor
//  {
//    internal string _queryType = "timeseries";

//    internal string _dimension;

//    internal TopNMetricSpec _metricSpec;

//    internal long _threshold;

//    internal bool _descending;

//    public override ITimeseriesQueryDescriptor Descending(bool descending)
//    {
//      _descending = descending;

//      return this;
//    }

//    internal override IDruidRequest Finalize()
//    {
//      var request = new TimeseriesRequest();
//      request.Build(this);

//      return request;
//    }
//  }
//}
