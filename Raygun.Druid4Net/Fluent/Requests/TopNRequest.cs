//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace Raygun.Druid4Net
//{
//  public class TopNRequest : IDruidRequest
//  {
//    public string Body { get; private set; }

//    public void Build<T>(T queryDescriptor)
//      where T :  IQueryDescriptor
//    {
//      var qd = queryDescriptor as TopNQueryDescriptor;

//      if (qd._granularitySpec != null)
//      {
//        Body = JsonConvert.SerializeObject(new
//        {
//          queryType = qd._queryType,
//          dataSource = qd._dataSource,
//          dimension = qd._dimension,
//          metric = qd._metricSpec,
//          granularity = qd._granularitySpec,
//          threshold = qd._threshold,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          aggregations = qd._aggregations,
//          postAggregations = qd._postAggregations,
//          context = qd._contextSpec
//        }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
//      }
//      else
//      {
//        Body = JsonConvert.SerializeObject(new
//        {
//          queryType = qd._queryType,
//          dataSource = qd._dataSource,
//          dimension = qd._dimension,
//          metric = qd._metricSpec,
//          granularity = qd._granularity,
//          threshold = qd._threshold,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          aggregations = qd._aggregations,
//          postAggregations = qd._postAggregations,
//          context = qd._contextSpec
//        }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
//      }
//    }
//  }
//}
