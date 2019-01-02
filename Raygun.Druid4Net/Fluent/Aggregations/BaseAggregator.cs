namespace Raygun.Druid4Net
{
  public abstract class BaseAggregator : IAggregationSpec
  {
    public abstract string Type { get; }

    public string FieldName { get; }

    public string Name { get; }

    protected BaseAggregator(string fieldName, string name = null)
    {
      FieldName = fieldName;
      Name = name ?? fieldName;
    }
  }
}