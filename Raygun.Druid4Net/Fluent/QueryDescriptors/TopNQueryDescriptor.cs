//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Raygun.Druid4Net
//{
//  public class TopNQueryDescriptor : QueryDescriptor, ITopNQueryDescriptor, IQueryDescriptor
//  {
//    internal string _queryType = "topN";

//    internal string _dimension;

//    internal TopNMetricSpec _metricSpec;

//    internal long _threshold;

//    public override ITopNQueryDescriptor Dimension(string dimension)
//    {
//      _dimension = dimension;

//      return this;
//    }

//    public override ITopNQueryDescriptor Metric(TopNMetricSpec metricSpec)
//    {
//      _metricSpec = metricSpec;

//      return this;
//    }

//    public override ITopNQueryDescriptor Threshold(long threshold)
//    {
//      _threshold = threshold;

//      return this;
//    }

//    internal override IDruidRequest Finalize()
//    {
//      var request = new TopNRequest();
//      request.Build(this);

//      return request;
//    }
//  }
//}
