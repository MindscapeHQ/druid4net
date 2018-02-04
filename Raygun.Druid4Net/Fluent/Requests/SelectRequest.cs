//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace Raygun.Druid4Net
//{
//  public class SelectRequest : IDruidRequest
//  {
//    public string Body { get; private set; }

//    public void Build<T>(T queryDescriptor) where T : IQueryDescriptor
//    {
//      var qd = queryDescriptor as SelectQueryDescriptor;

//      if (qd._granularitySpec != null)
//      {
//        Body = JsonConvert.SerializeObject(new
//        {
//          queryType = qd._queryType,
//          dataSource = qd._dataSource,
//          granularity = qd._granularitySpec,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          context = qd._contextSpec,
//          dimensions = qd._dimensions,
//          metrics = qd._metrics,
//          pagingSpec = qd._pagingSpec,
//          descending = qd._descending
//        }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
//      }
//      else
//      {
//        Body = JsonConvert.SerializeObject(new
//        {
//          queryType = qd._queryType,
//          dataSource = qd._dataSource,
//          granularity = qd._granularity,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          context = qd._contextSpec,
//          dimensions = qd._dimensions,
//          metrics = qd._metrics,
//          pagingSpec = qd._pagingSpec,
//          descending = qd._descending
//        }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
//      }
//    }
//  }
//}
