namespace Raygun.Druid4Net
{
  public class LookupDataSource : IDataSourceSpec, ILeftJoinDataSource, IRightJoinDataSource
  {
    public string Type => "lookup";

    public string Lookup { get; }

    public LookupDataSource(string lookup)
    {
      Lookup = lookup;
    }
  }
}