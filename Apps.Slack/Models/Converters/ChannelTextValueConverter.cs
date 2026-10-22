using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apps.Slack.Models.Converters;

public class ChannelTextValueConverter : JsonConverter<string>
{
    public override string? ReadJson(JsonReader reader, Type objectType, string? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        return token.Type switch
        {
            JTokenType.Null => null,
            JTokenType.String => token.Value<string>(),
            _ => token.Value<string>("value")
        };
    }

    public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
    {
        writer.WriteValue(value);
    }
}
