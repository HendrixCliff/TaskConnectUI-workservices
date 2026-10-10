using System.Net;

namespace WorkServices.Web.Services;

public sealed class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public string ResponseBody { get; }

    public ApiException(
        HttpStatusCode statusCode,
        string responseBody)
        : base(CreateMessage(statusCode, responseBody))
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }

    private static string CreateMessage(
        HttpStatusCode statusCode,
        string responseBody)
    {
        if (string.IsNullOrWhiteSpace(responseBody))
        {
            return $"API request failed with status {(int)statusCode} ({statusCode}).";
        }

        return
            $"API request failed with status {(int)statusCode} ({statusCode}): " +
            responseBody;
    }
}

