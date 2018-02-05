namespace Raygun.Druid4Net
{
  //public class AggregationSpec
  //{
  //  public string type;

  //  public string name;

  //  public string fieldName;

  //  public IFilterSpec filter;

  //  public AggregationSpec aggregator;

  //  public int? resolution;

  //  public float? lowerLimit;

  //  public float? upperLimit;

  //  public AggregationSpec(AggregationTypes type, string fieldName, string outputName)
  //  {
  //    this.type = type.ToString();
  //    this.fieldName = fieldName;
  //    this.name = outputName;
  //  }

  //  public AggregationSpec(AggregationTypes type, string fieldName, string outputName, int resolution)
  //  {
  //    this.type = type.ToString();
  //    this.fieldName = fieldName;
  //    this.name = outputName;
  //    this.resolution = resolution;
  //  }

  //  public AggregationSpec(AggregationTypes type, string fieldName, string outputName, int resolution, float? lowerLimit, float? upperLimit)
  //  {
  //    this.type = type.ToString();
  //    this.fieldName = fieldName;
  //    this.name = outputName;
  //    this.resolution = resolution;
  //    this.lowerLimit = lowerLimit;
  //    this.upperLimit = upperLimit;
  //  }

  //  public AggregationSpec(AggregationTypes type, FilterSpec filterSpec, AggregationSpec aggregationSpec)
  //  {
  //    this.type = type.ToString();
  //    this.filter = filterSpec;
  //    aggregator = aggregationSpec;
  //  }
  //}

  public enum AggregationTypes
  {
    count,

    longSum,

    doubleSum,

    doubleMin,

    doubleMax,

    longMin,

    longMax,

    cardinality,

    hyperUnique,

    filtered,

    approxHistogramFold,

    datasketchesQuantilesSketch,

    distinctCount
  }
}