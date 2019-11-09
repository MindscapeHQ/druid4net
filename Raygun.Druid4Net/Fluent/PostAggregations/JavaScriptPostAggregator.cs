using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class JavaScriptPostAggregator : IPostAggregationSpec
  {
    public string Type => "javascript";
    
    public string Name { get; }
    
    public IEnumerable<string> FieldNames { get; }
    
    public string Function { get; }

    public JavaScriptPostAggregator(string name, string function, IEnumerable<string> fieldNames)
    {
      Name = name;
      Function = function;
      FieldNames = fieldNames;
    }

    public JavaScriptPostAggregator(string name, string function, params string[] fieldNames)
    {
      Name = name;
      Function = function;
      FieldNames = fieldNames;
    }
  }
}