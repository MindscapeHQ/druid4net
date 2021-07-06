using System.Text.Json;
using System.Text.Json.Serialization;

namespace Raygun.Druid4Net
{
  public class DefaultJsonSerializer : IJsonSerializer
  {
    private readonly JsonSerializerOptions _options;
    
    public DefaultJsonSerializer(JsonSerializerOptions options = null)
    {
      _options = options ?? new JsonSerializerOptions
      {
        IgnoreNullValues = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
          new JsonStringEnumConverter(),
          new GenericTypeConverter<IAggregationSpec>(),
          new GenericTypeConverter<IPostAggregationSpec>(),
          new GenericTypeConverter<ITopNMetricSpec>(),
          new GenericTypeConverter<IDimensionSpec>(),
          new GenericTypeConverter<IExtractionFunction>(),
          new GenericTypeConverter<IFilterSpec>(),
          new GenericTypeConverter<IHavingSpec>(),
          new GenericTypeConverter<ISearchFilterQuery>(),
          new GenericTypeConverter<IGranularitySpec>(),
          new GenericTypeConverter<ILimitSpec>(),
          new GenericTypeConverter<IToIncludeSpec>(),
          new GenericTypeConverter<ISearchQuerySpec>(),
        }
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