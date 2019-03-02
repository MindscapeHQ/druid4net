namespace Raygun.Druid4Net
{
  public interface IDruidRequest<out TRequest>
  {
    TRequest RequestData { get; }
  }
}