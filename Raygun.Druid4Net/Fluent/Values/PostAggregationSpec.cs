using System.Collections;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class PostAggregationSpec
  {
    internal string type;

    internal string name;

    internal string fn;

    internal IEnumerable<PostAggregationSpec> fields;

    internal string fieldName;

    internal string ordering = null; // null | "numericFirst"

    internal IEnumerable<double> probabilities;

    public PostAggregationSpec(PostAggregationType type, string name, string fn, IEnumerable<PostAggregationSpec> fields)
    {
      this.type = type.ToString();
      this.name = name;
      this.fn = fn;
      this.fields = fields;
    }

    public PostAggregationSpec(PostAggregationType type, string name, string fieldName)
    {
      this.type = type.ToString();
      this.name = name;
      this.fieldName = fieldName;
    }

    public PostAggregationSpec(PostAggregationType type, string name, string fieldName, IEnumerable<double> probabilities)
    {
      this.type = type.ToString();
      this.name = name;
      this.fieldName = fieldName;
      this.probabilities = probabilities;
    }
  }

  public enum PostAggregationType
  {
    arithmetic,

    fieldAccess,

    constant,

    javascript,

    hyperUniqueCardinality,

    equalBuckets,

    buckets,

    customBuckets,

    min,

    max,

    quantile,

    quantiles,

    datasketchesQuantiles
  }
}