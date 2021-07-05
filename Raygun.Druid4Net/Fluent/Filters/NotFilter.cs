using System;

namespace Raygun.Druid4Net
{
  public class NotFilter : IFilterSpec
  {
    public string Type => "not";

    public IFilterSpec Field { get; }

    public NotFilter(IFilterSpec filter)
    {
      Field = filter;
    }
 }
}
