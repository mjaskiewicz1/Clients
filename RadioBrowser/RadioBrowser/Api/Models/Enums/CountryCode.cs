using System.Text.Json.Serialization;

using JetBrains.Annotations;

namespace RadioBrowser.Api.Models.Enums;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public enum CountryCode
{
    [JsonStringEnumMemberName("PL")] Pl,
    [JsonStringEnumMemberName("GB")] Gb,
    [JsonStringEnumMemberName("DE")] De,
    [JsonStringEnumMemberName("US")] Us,
    [JsonStringEnumMemberName("ES")] Es
}