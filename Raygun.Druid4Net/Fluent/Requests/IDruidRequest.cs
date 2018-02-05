namespace Raygun.Druid4Net
{
  public interface IDruidRequest<out TResponse> where TResponse : class
  {
    TResponse RequestData { get; }
  }
}