using System.Net.Http.Json;
using WorkServices.Web.Features.ServiceRequests.Models;

namespace WorkServices.Web.Features.ServiceRequests;

public sealed class ServiceRequestService
{
    private readonly HttpClient _httpClient;

    public ServiceRequestService(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceRequestDto?> CreateAsync(
        CreateServiceRequestRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsJsonAsync(
                "service-requests",
                request,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<ServiceRequestDto>(
                cancellationToken);
    }

    public async Task<List<ServiceRequestDto>> GetMyAsync(
        CancellationToken cancellationToken = default)
    {
        var result =
            await _httpClient.GetFromJsonAsync<
                List<ServiceRequestDto>>(
                "service-requests/my",
                cancellationToken);

        return result ?? [];
    }

    public async Task<ServiceRequestDto?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<
            ServiceRequestDto>(
            $"service-requests/{id}",
            cancellationToken);
    }

    public async Task<List<ServiceRequestDto>>
        GetCustomerRequestsAsync(
            Guid customerId,
            CancellationToken cancellationToken = default)
    {
        var result =
            await _httpClient.GetFromJsonAsync<
                List<ServiceRequestDto>>(
                $"service-requests/customer/{customerId}",
                cancellationToken);

        return result ?? [];
    }

    public async Task<List<ServiceRequestDto>>
        GetArtisanRequestsAsync(
            Guid artisanId,
            CancellationToken cancellationToken = default)
    {
        var result =
            await _httpClient.GetFromJsonAsync<
                List<ServiceRequestDto>>(
                $"service-requests/artisan/{artisanId}",
                cancellationToken);

        return result ?? [];
    }
}