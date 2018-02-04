namespace Raygun.Druid4Net
{
  internal class QueryBase
  {
    public string QueryType { get; set; }
    public string DataSource { get; set; }
    public string[] Intervals { get; set; }
    public IFilterSpec Filter { get; set; }
    public object Granularity { get; set; }
  }

  internal class SelectQuery : QueryBase
  {
    public bool Descending { get; set; }
    public string[] Dimensions { get; set; }
    public string[] Metrics { get; set; }
    public PagingSpec PagingSpec { get; set; }
    public object Context { get; set; }
  }
}