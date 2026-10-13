
using WorkServices.Web.Features.ServiceRequests.Models;
using WorkServices.Web.Services;

namespace WorkServices.Web.Features.ServiceRequests;

public sealed class ServiceRequestService
{
    private readonly ApiClient _api;

    public ServiceRequestService(ApiClient api)
    {
        _api = api;
    }

    public async Task CreateAsync(
        CreateServiceRequestRequest request,
        CancellationToken cancellationToken = default)
    {
        await _api.PostAsync(
            "service-requests",
            request,
            cancellationToken);
    }

    
    public async Task<List<CustomerRequestDto>> GetMyAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<CustomerRequestDto>>(
            "service-requests/my",
            cancellationToken);

        return result ?? [];
    }

    public Task<ServiceRequestDto?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return _api.GetAsync<ServiceRequestDto>(
            $"service-requests/{id}",
            cancellationToken);
    }

    public async Task<List<ServiceRequestDto>> GetCustomerRequestsAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<ServiceRequestDto>>(
            $"service-requests/customer/{customerId}",
            cancellationToken);

        return result ?? [];
    }

    public async Task<List<ServiceRequestDto>> GetArtisanRequestsAsync(
        Guid artisanId,
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<ServiceRequestDto>>(
            $"service-requests/artisan/{artisanId}",
            cancellationToken);

        return result ?? [];
    }
}
