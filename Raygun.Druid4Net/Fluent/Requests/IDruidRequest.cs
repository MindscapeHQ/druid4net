namespace Raygun.Druid4Net
{
  public interface IDruidRequest<out TRequest> where TRequest : QueryRequestData
  {
    TRequest RequestData { get; }
  }
}