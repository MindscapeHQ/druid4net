namespace Raygun.Druid4Net
{
  public abstract class SumAggregator : IAggregationSpec
  {
    public abstract string Type { get; }

    public string Name { get; }

    public string FieldName { get; }

    protected SumAggregator(string name, string fieldName)
    {
      Name = name;
      FieldName = fieldName;
    }
  }
}