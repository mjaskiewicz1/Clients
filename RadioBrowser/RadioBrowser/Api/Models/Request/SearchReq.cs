using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

using JetBrains.Annotations;

using RadioBrowser.Api.Models.Enums;

namespace RadioBrowser.Api.Models.Request;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed record SearchReq
{
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("countrycode")] public CountryCode? CountryCode { get; init; }
    [JsonPropertyName("state")] public string? State { get; init; }
    [JsonPropertyName("codec")] public Codec? Codec { get; init; }
}