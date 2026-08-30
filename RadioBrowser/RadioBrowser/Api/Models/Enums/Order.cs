using System.Text.Json.Serialization;

namespace RadioBrowser.Api.Models.Enums;

public enum Order
{
    [JsonStringEnumMemberName("name")] Name,
    [JsonStringEnumMemberName("votes")] Votes,
    [JsonStringEnumMemberName("clickcount")] ClickCount,
    [JsonStringEnumMemberName("clicktrend")] ClickTrend
}