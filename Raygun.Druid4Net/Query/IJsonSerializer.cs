namespace Raygun.Druid4Net
{
  public interface IJsonSerializer
  {
    string Serialize<TRequest>(TRequest request);
    TResponse Deserialize<TResponse>(string responseData);
  }
}