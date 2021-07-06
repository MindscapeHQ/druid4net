using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class HLLSketchUnion : IPostAggregationSpec
  {
    private const short DefaultLgK = 12;
    private const HLLType DefaultHLLType = HLLType.HLL_4;
    
    public string Type => "HLLSketchUnion";

    public string Name { get; }

    public IEnumerable<FieldAccessPostAggregator> Fields { get; }

    public int LgK { get; }
    
    public HLLType TgtHllType { get; }

    public HLLSketchUnion(string name, IEnumerable<FieldAccessPostAggregator> fields)
      : this(name, DefaultLgK, DefaultHLLType, fields)
    {
    }

    public HLLSketchUnion(string name, int lgK, HLLType tgtHllType, IEnumerable<FieldAccessPostAggregator> fields)
    {
      Name = name;
      Fields = fields;
      LgK = lgK;
      TgtHllType = tgtHllType;
    }

    public HLLSketchUnion(string name, params FieldAccessPostAggregator[] fields)
      : this(name, DefaultLgK, DefaultHLLType, fields)
    {
    }

    public HLLSketchUnion(string name, int lgK, HLLType tgtHllType, params FieldAccessPostAggregator[] fields)
    {
      Name = name;
      Fields = fields;
      LgK = lgK;
      TgtHllType = tgtHllType;
    }
  }
}