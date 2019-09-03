namespace Raygun.Druid4Net
{
  public class HyperUniqueCardinalityPostAggregator : IPostAggregationSpec
  {
    public virtual string Type => "hyperUniqueCardinality";

    public string Name { get; }

    public string FieldName { get; }

    public HyperUniqueCardinalityPostAggregator(string name, string fieldName)
    {
      Name = name;
      FieldName = fieldName;
    }
  }
}