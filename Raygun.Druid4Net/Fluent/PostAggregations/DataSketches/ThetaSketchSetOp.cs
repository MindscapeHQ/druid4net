using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ThetaSketchSetOp : IThetaSketchFieldAccessor
  {
    private const int DefaultSize = 16384;
    
    public string Type => "thetaSketchSetOp";

    public string Name { get; }
    
    public ThetaSketchSetOpFunction Func { get; }
    
    public IEnumerable<IThetaSketchFieldAccessor> Fields { get; }

    public int Size { get; }

    public ThetaSketchSetOp(string name, ThetaSketchSetOpFunction func, IEnumerable<IThetaSketchFieldAccessor> fields)
      : this (name, func, DefaultSize, fields)
    {
    }

    public ThetaSketchSetOp(string name, ThetaSketchSetOpFunction func, int size, IEnumerable<IThetaSketchFieldAccessor> fields)
    {
      Name = name;
      Func = func;
      Fields = fields;
      Size = size;
    }
    
    public ThetaSketchSetOp(string name, ThetaSketchSetOpFunction func, params IThetaSketchFieldAccessor[] fields)
      : this (name, func, DefaultSize, fields)
    {
    }
    
    public ThetaSketchSetOp(string name, ThetaSketchSetOpFunction func, int size, params IThetaSketchFieldAccessor[] fields)
    {
      Name = name;
      Func = func;
      Fields = fields;
      Size = size;
    }
  }
}