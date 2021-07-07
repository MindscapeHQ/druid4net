namespace Raygun.Druid4Net
{
  public class HLLSketchMerge : BaseAggregator
  {
    public override string Type => "HLLSketchMerge";

    public short LgK { get; }
    
    public HLLType TgtHllType { get; }
    
    public bool Round { get; }

    public HLLSketchMerge(string name, string fieldName, short lgK = 12, HLLType tgtHllType = HLLType.HLL_4, bool round = false) 
      : base(name, fieldName)
    {
      LgK = lgK;
      TgtHllType = tgtHllType;
      Round = round;
    }
  }
}