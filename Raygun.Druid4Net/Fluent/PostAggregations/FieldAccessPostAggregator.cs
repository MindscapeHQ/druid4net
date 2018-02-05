namespace Raygun.Druid4Net.Fluent.PostAggreations
{
  public class FieldAccessPostAggregator : IPostAggregationSpec
  {
    public string Type => "fieldAccess";

    public string Name { get; }

    public string FieldName { get; }

    public FieldAccessPostAggregator(string name, string fieldName)
    {
      Name = name;
      FieldName = fieldName;
    }
  }
}