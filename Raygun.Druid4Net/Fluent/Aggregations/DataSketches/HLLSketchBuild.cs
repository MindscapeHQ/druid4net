namespace Raygun.Druid4Net
{
  public class HLLSketchBuild : BaseAggregator
  {
    public override string Type => "HLLSketchBuild";

    public short LgK { get; }
    
    public HLLType TgtHllType { get; }
    
    public bool Round { get; }

    public HLLSketchBuild(string name, string fieldName, short lgK = 12, HLLType tgtHllType = HLLType.HLL_4, bool round = false) 
      : base(name, fieldName)
    {
      LgK = lgK;
      TgtHllType = tgtHllType;
      Round = round;
    }
  }
}