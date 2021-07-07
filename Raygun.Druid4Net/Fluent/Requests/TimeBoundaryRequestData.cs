namespace Raygun.Druid4Net
{
  public class TimeBoundaryRequestData : DatasourceQueryRequestData
  {
    public string QueryType => "timeBoundary";
    public IFilterSpec Filter { get; }
    public string Bound { get; }
    public IContextSpec Context { get; }

    public TimeBoundaryRequestData(string dataSource, string bound, IFilterSpec filter, IContextSpec context)
    {
      DataSource = dataSource;
      Bound = bound;
      Filter = filter;
      Context = context;
    }
  }
}