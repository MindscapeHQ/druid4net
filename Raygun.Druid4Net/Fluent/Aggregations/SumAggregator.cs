namespace Raygun.Druid4Net.Fluent.Aggregations
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