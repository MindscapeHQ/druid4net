namespace Raygun.Druid4Net
{
  public class StringLastAggregator : BaseAggregator
  {
    public override string Type => "stringLast";
    
    public int MaxStringBytes { get; }
    
    public bool FilterNullValues { get; }

    public StringLastAggregator(string name, string fieldName, int maxStringBytes = 1024, bool filterNullValues = false) 
      : base(name, fieldName)
    {
      MaxStringBytes = maxStringBytes;
      FilterNullValues = filterNullValues;
    }
  }
}