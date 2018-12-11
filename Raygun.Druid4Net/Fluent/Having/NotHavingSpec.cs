namespace Raygun.Druid4Net
{
  public class NotHavingSpec : IHavingSpec
  {
    public string Type => "not";

    public IHavingSpec HavingSpec { get; }

    public NotHavingSpec(IHavingSpec havingSpec)
    {
      HavingSpec = havingSpec;
    }
  }
}