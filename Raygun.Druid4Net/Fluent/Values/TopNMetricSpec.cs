using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public class TopNMetricSpec
  {
    internal object metric;

    internal string previousStop;

    internal string type;

    public TopNMetricSpec Metric(string metricName)
    {
      type = "numeric";
      metric = metricName;

      return this;
    }

    public TopNMetricSpec Inverted(TopNMetricSpec metricSpec)
    {
      type = "inverted";
      metric = metricSpec;

      return this;
    }

    public TopNMetricSpec Lexicographic(string previousStop)
    {
      type = "lexicographic";
      this.previousStop = previousStop;

      return this;
    }

    public TopNMetricSpec AlphaNumeric(string previousStop)
    {
      type = "alphaNumeric";
      this.previousStop = previousStop;

      return this;
    }

    public TopNMetricSpec Dimension()
    {
      type = "dimension";

      return this;
    }
  }
}
