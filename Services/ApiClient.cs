
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace WorkServices.Web.Services;

public sealed class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private static HttpRequestMessage CreateRequest(
        HttpMethod method,
        string uri)
    {
        var request = new HttpRequestMessage(method, uri);

        request.SetBrowserRequestCredentials(
            BrowserRequestCredentials.Include);

        return request;
    }

    public async Task<T?> GetAsync<T>(
        string uri,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(HttpMethod.Get, uri);

        using var response = await _httpClient.SendAsync(
            request,
            cancellationToken);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return default;
        }

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(response.StatusCode, body);
        }

        return await response.Content.ReadFromJsonAsync<T>(
            cancellationToken: cancellationToken);
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(
        string uri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        using var httpRequest = CreateRequest(
            HttpMethod.Post,
            uri);

        httpRequest.Content = JsonContent.Create(request);

        using var response = await _httpClient.SendAsync(
            httpRequest,
            cancellationToken);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return default;
        }

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(response.StatusCode, body);
        }

        return await response.Content.ReadFromJsonAsync<TResponse>(
            cancellationToken: cancellationToken);
    }

    public async Task PostAsync<TRequest>(
        string uri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        using var httpRequest = CreateRequest(
            HttpMethod.Post,
            uri);

        httpRequest.Content = JsonContent.Create(request);

        using var response = await _httpClient.SendAsync(
            httpRequest,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(response.StatusCode, body);
        }
    }

    public async Task PostAsync(
        string uri,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(
            HttpMethod.Post,
            uri);

        using var response = await _httpClient.SendAsync(
            request,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(response.StatusCode, body);
        }
    }

    public async Task<HttpResponseMessage> PostJsonAsync<TRequest>(
        string uri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        using var httpRequest = CreateRequest(
            HttpMethod.Post,
            uri);

        httpRequest.Content = JsonContent.Create(request);

        return await _httpClient.SendAsync(
            httpRequest,
            cancellationToken);
    }

    public async Task<HttpResponseMessage> GetRawAsync(
        string uri,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(
            HttpMethod.Get,
            uri);

        return await _httpClient.SendAsync(
            request,
            cancellationToken);
    }
}