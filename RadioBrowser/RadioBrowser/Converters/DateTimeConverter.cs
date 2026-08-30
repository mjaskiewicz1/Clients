using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

public sealed class DateTimeConverter : JsonConverter<DateTime?>
{
    private const string ApiDateFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType != JsonTokenType.String)
            throw new RadioBrowserException("Radio Browser returned an invalid DateTimeOffset token. Expected a string.");

        var value = reader.GetString();

        if (string.IsNullOrEmpty(value))
            return null;
        try
        {
            return DateTime.ParseExact(value, ApiDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }
        catch (Exception exception)
        {
            throw new RadioBrowserException($"Radio Browser returned an invalid DateTime value: '{value}'.", exception);
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString("O", CultureInfo.InvariantCulture));
    }
}