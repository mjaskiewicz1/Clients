using System.Collections.Immutable;

using Microsoft.Extensions.Logging;

using RadioBrowser.Api.Models.Response;
using RadioBrowser.Infrastructure;

using RestSharp;

namespace RadioBrowser;

public sealed class RadioBrowserClient(IRestClient client, ILogger? logger) : BaseClient(client)
{
    public static RadioBrowserClient Factory(ILogger? logger = null){
#pragma warning disable S1075
        var options = new RestClientOptions(new Uri("https://de1.api.radio-browser.info/json"));
#pragma warning restore S1075
        var client = new RestClient(options);
        return new RadioBrowserClient(client, logger);
    }
    
    public Task<ImmutableList<StationRes>> GetStationsAsync(string query, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest(new Uri($"/stations/search?{query}", UriKind.Relative));
        return RequestAsync<ImmutableList<StationRes>>(request);
   
    }
}