namespace Raygun.Druid4Net
{
  public abstract class BaseAggregator : IAggregationSpec
  {
    public abstract string Type { get; }

    public string Name { get; }

    public string FieldName { get; }

    protected BaseAggregator(string name, string fieldName = null)
    {
      Name = name;
      FieldName = fieldName ?? name;
    }
  }
}