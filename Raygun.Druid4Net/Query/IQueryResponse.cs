namespace Raygun.Druid4Net
{
  public interface IQueryResponse<out T>
  {
    T Data { get; }

    QueryRequestData RequestData { get; }
  }
}
