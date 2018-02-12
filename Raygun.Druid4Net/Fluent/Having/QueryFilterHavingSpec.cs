namespace Raygun.Druid4Net
{
  public class QueryFilterHavingSpec : IHavingSpec
  {
    public string Type => "filter";

    public IFilterSpec Filter { get; }

    public QueryFilterHavingSpec(IFilterSpec filter)
    {
      Filter = filter;
    }
  }
}