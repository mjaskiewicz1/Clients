using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

public sealed class BoolConverter :JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,

            JsonTokenType.String => reader.GetString() switch
            {
                "1" => true,
                "0" => false,
                "true" => true,
                "false" => false,
                _ => throw new RadioBrowserException($"Radio Browser returned an invalid boolean value '{reader.GetString()}'.")
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

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
       writer.WriteBooleanValue(value);
    }
}
