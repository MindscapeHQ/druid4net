namespace Raygun.Druid4Net
{
  public class StringFirstAggregator : BaseAggregator
  {
    public override string Type => "stringFirst";

    public int MaxStringBytes { get; }
    
    public bool FilterNullValues { get; }

    public StringFirstAggregator(string fieldName, string name = null, int maxStringBytes = 1024, bool filterNullValues = false) : base(fieldName, name)
    {
      MaxStringBytes = maxStringBytes;
      FilterNullValues = filterNullValues;
    }
  }
}