using System.Text.Json;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

namespace RadioBrowser.Converters;

/// <summary>
/// Converts an empty URI value returned by Radio Browser to <see langword="null"/>.
/// </summary>
public sealed class EmptyStringToNullUriConverter : JsonConverter<Uri>
{
    public override Uri? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType != JsonTokenType.String)
            throw new RadioBrowserException($"Radio Browser returned an invalid URI token: '{reader.TokenType}'.");

        var value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
            return null;

        try
        {
            return new Uri(value, UriKind.Absolute);
        }
        catch (UriFormatException exception)
        {
            throw new RadioBrowserException($"Radio Browser returned an invalid URI value: '{value}'.", exception);
        }
    }

    public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.AbsoluteUri);
    }
}