namespace Raygun.Druid4Net
{
  public class DruidResponse<T> : IQueryResponse<T>
  {
    public T Data { get; set; }

    public DruidQueryRequestData RequestData { get; set; }
  }
}
