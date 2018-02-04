namespace Raygun.Druid4Net
{
  public class PagingSpec
  {
    public dynamic PagingIdentifiers { get; }

    public long Threshold { get; }

    public PagingSpec(long threshold)
    {
      Threshold = threshold;
    }

    public PagingSpec(long threshold, dynamic pagingIdentifiers)
    {
      Threshold = threshold;
      PagingIdentifiers = pagingIdentifiers;
    }
  }
}