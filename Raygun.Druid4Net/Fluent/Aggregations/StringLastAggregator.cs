namespace Raygun.Druid4Net
{
  public class StringLastAggregator : BaseAggregator
  {
    public override string Type => "stringLast";
    
    public int MaxStringBytes { get; }
    
    public bool FilterNullValues { get; }

    public StringLastAggregator(string fieldName, string name = null, int maxStringBytes = 1024, bool filterNullValues = false) : base(fieldName, name)
    {
      MaxStringBytes = maxStringBytes;
      FilterNullValues = filterNullValues;
    }
  }
}