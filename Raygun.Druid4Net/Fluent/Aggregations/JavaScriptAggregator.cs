using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class JavaScriptAggregator : IAggregationSpec
  {
    public string Type => "javascript";

    public string Name { get; }
    
    public IEnumerable<string> FieldNames { get; }
    
    public string FnAggregate { get; }
    
    public string FnCombine { get; }
    
    public string FnReset { get; }

    public JavaScriptAggregator(string name, string fnAggregate, string fnCombine, string fnReset, IEnumerable<string> fieldNames)
    {
      Name = name;
      FieldNames = fieldNames;
      FnAggregate = fnAggregate;
      FnCombine = fnCombine;
      FnReset = fnReset;
    }

    public JavaScriptAggregator(string name, string fnAggregate, string fnCombine, string fnReset, params string[] fieldNames)
    {
      Name = name;
      FieldNames = fieldNames;
      FnAggregate = fnAggregate;
      FnCombine = fnCombine;
      FnReset = fnReset;
    }
  }
}