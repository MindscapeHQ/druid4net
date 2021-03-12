using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SearchQueryDescriptor : QueryDescriptor, ISearchQueryDescriptor
  {
    internal int LimitValue;

    internal ISearchQuerySpec QueryValue;
    
    internal SortSpec SortValue;

    internal IEnumerable<string> SearchDimensionsValue;

    internal ContextSpec ContextValue;

    public SearchQueryDescriptor()
    {
      ContextValue = new ContextSpec();
      SortValue = new SortSpec();
    }

    public ISearchQueryDescriptor SearchDimensions(params string[] dimensions)
    {
      SearchDimensionsValue = dimensions;
      return this;
    }

    public ISearchQueryDescriptor SearchDimensions(IEnumerable<string> dimensions)
    {
      SearchDimensionsValue = dimensions;
      return this;
    }

    public ISearchQueryDescriptor Query(ISearchQuerySpec querySpec)
    {
      QueryValue = querySpec;
      return this;
    }

    public ISearchQueryDescriptor Limit(int limit)
    {
      LimitValue = limit;
      return this;
    }

    public ISearchQueryDescriptor Sort(SortingOrder sortingOrder)
    {
      SortValue.Type = sortingOrder;
      return this;
    }
    
    public ISearchQueryDescriptor Interval(DateTime from, DateTime to)
    {
      SetInterval(from, to);      
      return this;
    }

    public ISearchQueryDescriptor Intervals(params Interval[] intervals)
    {
      SetIntervals(intervals);
      return this;
    }

    public ISearchQueryDescriptor Intervals(IEnumerable<Interval> intervals)
    {
      SetIntervals(intervals);
      return this;
    }
    
    public ISearchQueryDescriptor DataSource(string dataSource)
    {
      DataSourceValue = dataSource;
      return this;
    }

    public ISearchQueryDescriptor Granularity(Granularities granularity)
    {
      SetGranularity(granularity);
      return this;
    }
    
    public ISearchQueryDescriptor Granularity(IGranularitySpec granularitySpec)
    {
      GranularityValue = granularitySpec;
      return this;
    }

    public ISearchQueryDescriptor Filter(IFilterSpec filterSpec)
    {
      FilterValue = filterSpec;
      return this;
    }
    
    public ISearchQueryDescriptor Context(int? timeout = null, long? maxScatterGatherBytes = null, int? priority = null, string queryId = null, bool? useCache = null, bool? populateCache = null, bool? bySegment = null, bool? finalize = null, string chunkPeriod = null, bool? serializeDateTimeAsLong = null, bool? serializeDateTimeAsLongInner = null, SearchStrategy? strategy = null)
    {
      SetCommonContextProperties(ContextValue, timeout, maxScatterGatherBytes, priority, queryId, useCache, populateCache, bySegment, finalize, chunkPeriod, serializeDateTimeAsLong, serializeDateTimeAsLongInner, strategy);
      return this;
    }

    public IDruidRequest<SearchRequestData> Generate()
    {
      var request = new SearchRequest();
      request.Build(this);
      return request;
    } 
  }
}
