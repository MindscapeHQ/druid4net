namespace Raygun.Druid4Net
{
  public class StringAnyAggregator : BaseAggregator
  {
    public override string Type => "stringAny";

    public int? MaxStringBytes { get; }

    public StringAnyAggregator(string name, string fieldName, int? maxStringBytes = 1024) 
      : base (name, fieldName)
    {
      MaxStringBytes = maxStringBytes;
    }
  }
}