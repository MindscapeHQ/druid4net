using Jil;

namespace Raygun.Druid4Net.IntegrationTests
{
  public class JilSerializer : IJsonSerializer
  {
    private readonly Options _serializationOptions;
    private readonly Options _deserializationOptions;

    public JilSerializer()
    {
      _serializationOptions = new Options(prettyPrint: false, excludeNulls: true, includeInherited: true, serializationNameFormat: SerializationNameFormat.CamelCase);
      _deserializationOptions = new Options(serializationNameFormat: SerializationNameFormat.CamelCase, dateFormat: DateTimeFormat.ISO8601);
    }

    public string Serialize<TRequest>(TRequest request)
    {
      return JSON.SerializeDynamic(request, _serializationOptions);
    }

    public TResponse Deserialize<TResponse>(string responseData)
    {
      return JSON.Deserialize<TResponse>(responseData, _deserializationOptions);
    }
  }
}