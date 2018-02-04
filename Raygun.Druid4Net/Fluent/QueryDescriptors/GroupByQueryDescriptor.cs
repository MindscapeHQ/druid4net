//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Raygun.Druid4Net
//{
//  public class GroupByQueryDescriptor : QueryDescriptor, IGroupByQueryDescriptor
//  {
//    internal string _queryType = "groupBy";

//    internal HavingSpec _havingSpec;

//    internal IEnumerable<string> _dimensions;

//    internal LimitSpec _limitSpec;

//    internal dynamic _innerGroupByDataSource;

//    public override IGroupByQueryDescriptor Having(HavingSpec havingSpec)
//    {
//      _havingSpec = havingSpec;

//      return this;
//    }

//    public override IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions)
//    {
//      _dimensions = dimensions;

//      return this;
//    }

//    public override IGroupByQueryDescriptor Limit(LimitSpec limitSpec)
//    {
//      _limitSpec = limitSpec;

//      return this;
//    }

//    internal override IDruidRequest Finalize()
//    {
//      var request = new GroupByRequest();
//      request.Build(this);

//      return request;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.DataSource(string dataSource)
//    {
//      DataSource(dataSource);

//      return this;
//    }

//    public IGroupByQueryDescriptor DataSource(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> innerGroupByQueryDescriptor)
//    {
//      var qd = ((GroupByQueryDescriptor)innerGroupByQueryDescriptor(new GroupByQueryDescriptor()));

//      var dataSource = new GroupByRequest().BuildDynamic(qd);

//      _innerGroupByDataSource = new
//      {
//        type = "query",
//        query = dataSource
//      };

//      return this;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.Granularity(Granularities granularity)
//    {
//      Granularity(granularity);

//      return this;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.Intervals(DateTime dateFrom, DateTime dateTo)
//    {
//      Intervals(dateFrom, dateTo);

//      return this;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.Filter(FilterSpec filterSpec)
//    {
//      Filter(filterSpec);

//      return this;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.Aggregations(IEnumerable<AggregationSpec> aggregationsSpec)
//    {
//      Aggregations(aggregationsSpec);

//      return this;
//    }

//    IGroupByQueryDescriptor IGroupByQueryDescriptor.PostAggregations(IEnumerable<PostAggregationSpec> postAggregationsSpec)
//    {
//      PostAggregations(postAggregationsSpec);

//      return this;
//    }
//  }
//}
