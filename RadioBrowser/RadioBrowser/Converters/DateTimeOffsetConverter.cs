using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

public sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType != JsonTokenType.String)
            throw new RadioBrowserException("Radio Browser returned an invalid DateTimeOffset token. Expected a string.");

        var value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
            return null;
        try
        {
            return DateTimeOffset.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }
        catch (Exception exception)
        {
            throw new RadioBrowserException($"Radio Browser returned an invalid DateTime value: '{value}'.", exception);
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value.Value.ToString("O", CultureInfo.InvariantCulture));
    }
}