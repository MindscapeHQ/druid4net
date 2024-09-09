using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Raygun.Druid4Net.IntegrationTests;

public class NewtonsoftSerializer : IJsonSerializer
{
  private readonly JsonSerializerSettings _settings = new()
  {
    ContractResolver = new CamelCasePropertyNamesContractResolver(),
    NullValueHandling = NullValueHandling.Ignore,
    Converters = new List<JsonConverter>
    {
      new StringEnumConverter()
    }
  };

  public string Serialize<TRequest>(TRequest request)
  {
    return JsonConvert.SerializeObject(request, _settings);
  }

  public TResponse Deserialize<TResponse>(string responseData)
  {
    return JsonConvert.DeserializeObject<TResponse>(responseData, _settings);
  }
}