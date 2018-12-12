using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public abstract class QueryRequestData
  {
    public object DataSource { get; internal set; }
    public object Granularity { get; internal set; }
    public IList<string> Intervals { get; internal set; }
    public IFilterSpec Filter { get; internal set; }
  }
}