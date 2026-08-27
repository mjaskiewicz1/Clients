using System.Net;

namespace RadioBrowser.Exceptions;

public sealed class RadioBrowserException : Exception
{
    private readonly HttpStatusCode _statusCode;
    public RadioBrowserException()
    {
    }

    public RadioBrowserException(string? message) : base(message)
    {
    }

    public RadioBrowserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    public RadioBrowserException(string? message, HttpStatusCode statusCode) : base(message)
    {
        _statusCode = statusCode;
    }
}