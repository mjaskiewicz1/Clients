using System.Text.Json.Serialization;

using JetBrains.Annotations;

namespace RadioBrowser.Api.Models.Response;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public sealed record StationRes
{
    [JsonPropertyName("changeuuid")] public required Guid ChangeUuid { get; init; }
    [JsonPropertyName("stationuuid")] public required Guid StationUuid { get; init; }
    [JsonPropertyName("serveruuid")] public Guid? ServerUuid { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("url")] public required Uri Url { get; init; }
    [JsonPropertyName("url_resolved")] public required Uri UrlResolved { get; init; }
    [JsonPropertyName("homepage")] public required Uri Homepage { get; init; }
    [JsonPropertyName("favicon")] public required Uri Favicon { get; init; }
    [JsonPropertyName("tags")] public required string Tags { get; init; }
    [JsonPropertyName("countrycode")] public required string CountryCode { get; init; }
    [JsonPropertyName("iso_3166_2")] public required string Iso31662 { get; init; }
    [JsonPropertyName("state")] public required string State { get; init; }
    [JsonPropertyName("language")] public required string Language { get; init; }
    [JsonPropertyName("languagecodes")] public required string LanguageCodes { get; init; }
    [JsonPropertyName("votes")] public required int Votes { get; init; }
    [JsonPropertyName("lastchangetime")] public DateTime? LastChangeTime { get; init; }
    [JsonPropertyName("lastchangetime_iso8601")] public DateTimeOffset? LastChangeTimeIso8601 { get; init; }
    [JsonPropertyName("codec")] public required string Codec { get; init; }
    [JsonPropertyName("bitrate")] public required int Bitrate { get; init; }
    [JsonPropertyName("lastcheckok")] public bool? LastCheckOk { get; init; }
    [JsonPropertyName("lastchecktime")] public DateTime? LastCheckTime { get; init; }
    [JsonPropertyName("lastchecktime_iso8601")] public DateTimeOffset? LastCheckTimeIso8601 { get; init; }
    [JsonPropertyName("lastcheckoktime")] public DateTime? LastCheckOkTime { get; init; }
    [JsonPropertyName("lastcheckoktime_iso8601")] public DateTimeOffset? LastCheckOkTimeIso8601 { get; init; }
    [JsonPropertyName("lastlocalchecktime")] public DateTime? LastLocalCheckTime { get; init; }
    [JsonPropertyName("lastlocalchecktime_iso8601")] public DateTimeOffset? LastLocalCheckTimeIso8601 { get; init; }
    [JsonPropertyName("clicktimestamp")] public DateTime? ClickTimestamp { get; init; }
    [JsonPropertyName("clicktimestamp_iso8601")] public DateTimeOffset? ClickTimestampIso8601 { get; init; }
    [JsonPropertyName("clickcount")] public required int ClickCount { get; init; }
    [JsonPropertyName("clicktrend")] public required int ClickTrend { get; init; }
    [JsonPropertyName("ssl_error")] public bool? SslError { get; init; }
    [JsonPropertyName("geo_lat")] public double? GeoLat { get; init; }
    [JsonPropertyName("geo_long")] public double? GeoLong { get; init; }
    [JsonPropertyName("geo_distance")] public double? GeoDistance { get; init; }
    [JsonPropertyName("has_extended_info")] public bool? HasExtendedInfo { get; init; }
}