using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

public sealed class DateTimeConverter : JsonConverter<DateTime>
{
    private const string ApiDateFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = GetDateValue(ref reader, nameof(DateTime));

        return DateTime.TryParseExact(value, ApiDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime) ||
            DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime)
            ? dateTime
            : throw new RadioBrowserException($"Radio Browser returned an invalid DateTime value: '{value}'.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("O", CultureInfo.InvariantCulture));
    }

    private static string GetDateValue(ref Utf8JsonReader reader, string typeName)
    {
        return reader.TokenType != JsonTokenType.String
            ? throw new RadioBrowserException($"Radio Browser returned an invalid {typeName} token. Expected a string.")
            : reader.GetString() ?? throw new RadioBrowserException($"Radio Browser returned a null {typeName} value.");
    }
}