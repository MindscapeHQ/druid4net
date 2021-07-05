using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class LookupMap
  {
    public string Type => "map";
    
    public IDictionary<string, string> Map { get; }
    
    public bool IsOneToOne { get; }

    public LookupMap(IDictionary<string, string> map, bool isOneToOne = false)
    {
      Map = map;
      IsOneToOne = isOneToOne;
    }
  }
}