namespace Raygun.Druid4Net
{
  public class HyperUniqueAggregator : IAggregationSpec
  {
    public string Type => "hyperUnique";

    public string Name { get; }
    
    public string FieldName { get; }
    
    public bool IsInputHyperUnique { get; }
    
    public bool Round { get; }

    public HyperUniqueAggregator(string fieldName, string name = null, bool isInputHyperUnique = false, bool round = false)
    {
      FieldName = fieldName;
      Name = name ?? fieldName;
      IsInputHyperUnique = isInputHyperUnique;
      Round = round;
    }
  }
}