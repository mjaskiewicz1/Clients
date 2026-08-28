using System.Collections.Immutable;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;

using RadioBrowser.Api.Models.Request;
using RadioBrowser.Api.Models.Response;
using RadioBrowser.Extensions;
using RadioBrowser.Infrastructure;

using RestSharp;

namespace RadioBrowser;

[UsedImplicitly(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.WithMembers, Reason = "Used as nuget package")]
public sealed class RadioBrowserClient(IRestClient client, ILogger? logger) : BaseClient(client)
{
    public static RadioBrowserClient Factory(ILogger? logger = null)
    {
        var options = new RestClientOptions(new Uri("https://de1.api.radio-browser.info/json"));
        var client = new RestClient(options);
        return new RadioBrowserClient(client, logger);
    }

    public Task<ImmutableList<StationRes>> GetStationsAsync(SearchReq? searchReq = null, uint offset = 0, uint limit = 100)
    {
        var request = new RestRequest(new Uri("/stations/search", UriKind.Relative)).AddQueryParameters(searchReq);
        request.AddQueryParameter("offset", offset.ToString()).AddQueryParameter("limit", limit.ToString());
        return RequestAsync<ImmutableList<StationRes>>(request);
    }
}