using System.Text.Json.Serialization;

using RadioBrowser.Api.Models.Enums;

namespace RadioBrowser.Api.Models.Request;

public record SearchReq
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("countrycode")]
    public CountryCode CountryCode { get; init; }
};