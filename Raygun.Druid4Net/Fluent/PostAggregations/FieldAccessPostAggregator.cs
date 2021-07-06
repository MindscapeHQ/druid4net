namespace Raygun.Druid4Net
{
  public class FieldAccessPostAggregator : IPostAggregationSpec, IThetaSketchFieldAccessor
  {
    public virtual string Type => "fieldAccess";

    public string Name { get; }

    public string FieldName { get; }

    public FieldAccessPostAggregator(string name, string fieldName)
    {
      Name = name;
      FieldName = fieldName;
    }
  }
}