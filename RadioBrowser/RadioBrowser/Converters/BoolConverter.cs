using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

public sealed class BoolConverter : JsonConverter<bool?>
{
    public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return reader.TokenType switch
        {
            JsonTokenType.Null => null,

            JsonTokenType.True => true,
            JsonTokenType.False => false,

            JsonTokenType.String => reader.GetString() switch
            {
                null => null,
                var value when string.IsNullOrWhiteSpace(value) => null,
                "1" => true,
                "0" => false,
                "true" => true,
                "false" => false,
                var value => throw new RadioBrowserException($"Radio Browser returned an invalid boolean value '{value}'.")
            },

            JsonTokenType.Number when reader.TryGetInt32(out var value) => value switch
            {
                1 => true,
                0 => false,
                _ => throw new RadioBrowserException($"Radio Browser returned an invalid boolean value '{value}'.")
            },

            _ => throw new RadioBrowserException($"Radio Browser returned an invalid boolean token '{reader.TokenType}'.")
        };
    }

    public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteBooleanValue(value.Value);
    }
}