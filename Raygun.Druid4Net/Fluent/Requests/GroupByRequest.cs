//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace Raygun.Druid4Net
//{
//  public class GroupByRequest : IDruidRequest
//  {
//    public string Body { get; private set; }

//    public void Build<T>(T queryDescriptor) where T : IQueryDescriptor
//    {
//      Body = JsonConvert.SerializeObject(BuildDynamic(queryDescriptor), Formatting.None, new JsonSerializerSettings
//      {
//        NullValueHandling = NullValueHandling.Ignore
//      });
//    }

//    public dynamic BuildDynamic<T>(T queryDescriptor)
//    {
//      var qd = queryDescriptor as GroupByQueryDescriptor;

//      dynamic datasource = qd._dataSource;
//      if (qd._innerGroupByDataSource != null)
//      {
//        datasource = qd._innerGroupByDataSource;
//      }

//      if (qd._granularitySpec != null)
//      {
//        return new
//        {
//          queryType = qd._queryType,
//          dataSource = datasource,
//          granularity = qd._granularitySpec,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          aggregations = qd._aggregations,
//          postAggregations = qd._postAggregations,
//          context = qd._contextSpec,
//          having = qd._havingSpec,
//          limitSpec = qd._limitSpec,
//          dimensions = qd._dimensions
//        };
//      }
//      else
//      {
//        return new
//        {
//          queryType = qd._queryType,
//          dataSource = datasource,
//          granularity = qd._granularity,
//          intervals = qd._intervals,
//          filter = qd._filterSpec,
//          aggregations = qd._aggregations,
//          postAggregations = qd._postAggregations,
//          context = qd._contextSpec,
//          having = qd._havingSpec,
//          limitSpec = qd._limitSpec,
//          dimensions = qd._dimensions
//        };
//      }
//    }
//  }
//}
