
namespace Raygun.Druid4Net
{
  public class TimeBoundaryRequestData : QueryRequestData
  {
    public string QueryType => "timeBoundary";
    public string Bound { get; internal set; }
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