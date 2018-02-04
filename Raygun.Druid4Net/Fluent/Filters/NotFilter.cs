using System;

namespace Raygun.Druid4Net
{
  public class NotFilter : IFilter
  {
    public string Type => "not";

    public IFilter Field;

    public NotFilter(IFilter filter)
    {
      Field = filter;
    }
 }
}
