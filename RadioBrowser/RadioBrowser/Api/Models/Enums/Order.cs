using System.Text.Json.Serialization;

using JetBrains.Annotations;

namespace RadioBrowser.Api.Models.Enums;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public enum Order
{
    [JsonStringEnumMemberName("name")] Name,
    [JsonStringEnumMemberName("url")] Url,
    [JsonStringEnumMemberName("homepage")] Homepage,
    [JsonStringEnumMemberName("favicon")] Favicon,
    [JsonStringEnumMemberName("tags")] Tags,
    [JsonStringEnumMemberName("country")] Country,
    [JsonStringEnumMemberName("state")] State,
    [JsonStringEnumMemberName("language")] Language,
    [JsonStringEnumMemberName("votes")] Votes,
    [JsonStringEnumMemberName("codec")] Codec,
    [JsonStringEnumMemberName("bitrate")] Bitrate,
    [JsonStringEnumMemberName("lastcheckok")] LastCheckOk,
    [JsonStringEnumMemberName("lastchecktime")] LastCheckTime,
    [JsonStringEnumMemberName("clicktimestamp")] ClickTimestamp,
    [JsonStringEnumMemberName("clickcount")] ClickCount,
    [JsonStringEnumMemberName("clicktrend")] ClickTrend,
    [JsonStringEnumMemberName("changetimestamp")] ChangeTimestamp,
    [JsonStringEnumMemberName("random")] Random
}