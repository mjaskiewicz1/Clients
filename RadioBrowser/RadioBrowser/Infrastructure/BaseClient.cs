using System.Text.Json;

using RadioBrowser.Exceptions;

using RestSharp;

namespace RadioBrowser.Infrastructure;

public class BaseClient(IRestClient client)
{
    private static readonly JsonSerializerOptions DeserializeSettings = new();

    protected async Task<T> RequestAsync<T>(RestRequest request) where T : class
    {
        var res = await client.ExecuteAsync(request).ConfigureAwait(false);

        if (!res.IsSuccessful)
        {
            throw new RadioBrowserException(
                $"[{request.Resource} => Status: {res.StatusCode}] Unsuccessful request!\nContent:\n{res.Content}",
                res.StatusCode);
        }

        if (string.IsNullOrWhiteSpace(res.Content))
        {
            throw new RadioBrowserException(
                $"[{request.Resource} => Status: {res.StatusCode}] Received empty response!", res.StatusCode);
        }

        try
        {
            var model = JsonSerializer.Deserialize<T>(res.Content, options: DeserializeSettings) ??
                        throw new RadioBrowserException(
                            $"Failed to deserialize [{request.Resource}] response! Content parsed to null.",
                            res.StatusCode);


            return model;
        }
        catch (JsonException ex)
        {
            throw new RadioBrowserException(
                $"Failed to deserialize [{request.Resource}] response due to invalid JSON format!", ex);
        }
    }
}