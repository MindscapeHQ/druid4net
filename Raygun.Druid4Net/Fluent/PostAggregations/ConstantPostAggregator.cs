namespace Raygun.Druid4Net
{
  public class ConstantPostAggregator<T> : IPostAggregationSpec
  {
    public virtual string Type => "constant";

    public string Name { get; }

    public T Value { get; }

    public ConstantPostAggregator(string name, T value)
    {
      Name = name;
      Value = value;
    }
  }
}