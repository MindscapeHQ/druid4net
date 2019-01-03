namespace Raygun.Druid4Net
{
  public class StringFirstAggregator : BaseAggregator
  {
    public override string Type => "stringFirst";

    public int MaxStringBytes { get; }
    
    public bool FilterNullValues { get; }

    public StringFirstAggregator(string name, string fieldName, int maxStringBytes = 1024, bool filterNullValues = false) 
      : base(name, fieldName)
    {
      MaxStringBytes = maxStringBytes;
      FilterNullValues = filterNullValues;
    }
  }
}