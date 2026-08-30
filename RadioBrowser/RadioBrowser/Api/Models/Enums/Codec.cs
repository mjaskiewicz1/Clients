using System.Text.Json.Serialization;

using JetBrains.Annotations;

namespace RadioBrowser.Api.Models.Enums;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public enum Codec
{
    [JsonStringEnumMemberName("MP3")] Mp3,
    [JsonStringEnumMemberName("AAC")] Aac,
    [JsonStringEnumMemberName("OGG")] Ogg,
    [JsonStringEnumMemberName("WMA")] Wma,
    [JsonStringEnumMemberName("FLAC")] Flac,
    [JsonStringEnumMemberName("OPUS")] Opus
}