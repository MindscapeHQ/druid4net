using System.Text.Json;

namespace Raygun.Druid4Net
{
  public class DefaultJsonSerializer : IJsonSerializer
  {
    private readonly JsonSerializerOptions _options;
    
    public DefaultJsonSerializer(JsonSerializerOptions options = null)
    {
      _options = options ?? new JsonSerializerOptions()
      {
        IgnoreNullValues = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };
    }

    public string Serialize<TRequest>(TRequest request)
    {
      return JsonSerializer.Serialize(request, _options);
    }

    public TResponse Deserialize<TResponse>(string responseData)
    {
      return JsonSerializer.Deserialize<TResponse>(responseData, _options);
    }
  }
}