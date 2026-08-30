using System.Text.Json.Serialization;

using JetBrains.Annotations;

using RadioBrowser.Api.Models.Enums;

namespace RadioBrowser.Api.Models.Request;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public sealed record SearchReq
{
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("countrycode")] public CountryCode? CountryCode { get; init; }
    [JsonPropertyName("state")] public string? State { get; init; }
    [JsonPropertyName("codec")] public Codec? Codec { get; init; }
    [JsonPropertyName("order")] public Order? Order { get; init; }
    [JsonPropertyName("reverse")] public bool? Reverse { get; init; }
    [JsonPropertyName("hidebroken")] public bool? HideBroken { get; init; }
}