using System.Text.Json.Serialization;

namespace RadioBrowser.Api.Models.Enums;

public enum Codec
{
    [JsonStringEnumMemberName("MP3")] Mp3,
    [JsonStringEnumMemberName("AAC")] Aac,
    [JsonStringEnumMemberName("OGG")] Ogg,
    [JsonStringEnumMemberName("WMA")] Wma,
    [JsonStringEnumMemberName("FLAC")] Flac,
    [JsonStringEnumMemberName("OPUS")] Opus
}