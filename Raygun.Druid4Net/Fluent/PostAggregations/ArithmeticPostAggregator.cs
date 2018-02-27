using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class ArithmeticPostAggregator : IPostAggregationSpec
  {
    public string Type => "arithmetic";

    public string Name { get; }

    public string Fn { get; }

    public IEnumerable<IPostAggregationSpec> Fields { get; }

    public string Ordering { get; }

    public ArithmeticPostAggregator(string name, IEnumerable<IPostAggregationSpec> fields, ArithmeticFunction fn, string ordering = null)
    {
      Name = name;
      Fields = fields;
      Ordering = ordering;

      switch (fn)
      {
        case ArithmeticFunction.Plus:
          Fn = "+";
          break;
        case ArithmeticFunction.Minus:
          Fn = "-";
          break;
        case ArithmeticFunction.Multiply:
          Fn = "*";
          break;
        case ArithmeticFunction.Divide:
          Fn = "/";
          break;
        case ArithmeticFunction.Quotient:
          Fn = "quotient";
          break;
      }
    }
  }

  public enum ArithmeticFunction
  {
    Plus,
    Minus,
    Multiply,
    Divide,
    Quotient
  }
}