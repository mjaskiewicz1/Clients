using System.Text.Json.Serialization;

namespace RadioBrowser.Api.Models.Enums;

public enum CountryCode
{
    [JsonStringEnumMemberName("PL")] Pl,
    [JsonStringEnumMemberName("GB")] Gb,
    [JsonStringEnumMemberName("DE")] De,
    [JsonStringEnumMemberName("US")] Us,
    [JsonStringEnumMemberName("ES")] Es
}