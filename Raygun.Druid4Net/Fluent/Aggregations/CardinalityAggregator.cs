using System.Collections.Generic;
using System.Linq;

namespace Raygun.Druid4Net
{
  public class CardinalityAggregator : IAggregationSpec
  {
    public string Type => "cardinality";

    public string Name { get; }
    
    public IEnumerable<IDimensionSpec> Fields { get; }
    
    public bool ByRow { get; }
    
    public bool Round { get; }

    public CardinalityAggregator(string name, IEnumerable<IDimensionSpec> fields, bool byRow = false, bool round = false)
    {
      Name = name;
      Fields = fields;
      ByRow = byRow;
      Round = round;
    }

    public CardinalityAggregator(string name, IEnumerable<string> fields, bool byRow = false, bool round = false)
    {
      Name = name;
      Fields = fields.Select(f => new DefaultDimension(f));
      ByRow = byRow;
      Round = round;
    }

    public CardinalityAggregator(string name, bool byRow, bool round, params IDimensionSpec[] fields)
      : this (name, fields, byRow, round)
    {
    }

    public CardinalityAggregator(string name, bool byRow, bool round, params string[] fields)
      : this (name, fields, byRow, round)
    {
    }
  }
}