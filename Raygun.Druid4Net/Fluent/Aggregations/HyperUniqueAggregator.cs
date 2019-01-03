namespace Raygun.Druid4Net
{
  public class HyperUniqueAggregator : BaseAggregator
  {
    public override string Type => "hyperUnique";

    public bool IsInputHyperUnique { get; }
    
    public bool Round { get; }

    public HyperUniqueAggregator(string name, string fieldName, bool isInputHyperUnique = false, bool round = false)
      : base(name, fieldName)
    {
      IsInputHyperUnique = isInputHyperUnique;
      Round = round;
    }
  }
}