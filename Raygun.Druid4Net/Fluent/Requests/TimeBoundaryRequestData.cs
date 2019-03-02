using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class TimeBoundaryRequestData
  {
    public string QueryType => "timeBoundary";
    public object DataSource { get; internal set; }
    public string Bound { get; internal set; }
    public IList<string> Intervals { get; internal set; }
    public IFilterSpec Filter { get; internal set; }
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