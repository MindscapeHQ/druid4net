namespace Raygun.Druid4Net
{
  public interface IDruidRequest<out TRequest> where TRequest : IQueryRequest
  {
    TRequest RequestData { get; }
  }
}