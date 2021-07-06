using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Raygun.Druid4Net
{
  public class GenericTypeConverter<T> : JsonConverter<T>
  {
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
      switch (value)
      {
        case null:
          JsonSerializer.Serialize(writer, default(T), options);
          break;
        default:
        {
          var type = value.GetType();
          JsonSerializer.Serialize(writer, value, type, options);
          break;
        }
      }
    }
  }
}