using System.Net.Http.Json;
using WorkServices.Web.Features.Payments.Models;
using WorkServices.Web.Services;
namespace WorkServices.Web.Features.Payments;

public sealed class PaymentService
{
    private readonly ApiClient _api;

    public PaymentService(ApiClient api)
    {
        _api = api;
    }

    public async Task<List<PaymentDto>> GetByServiceRequestAsync(
        Guid serviceRequestId,
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<PaymentDto>>(
            $"payments/service-request/{serviceRequestId}",
            cancellationToken);

        return result ?? [];
    }

    public async Task<PaymentInitializationDto?> InitializeAsync(
        Guid paymentId,
        CancellationToken cancellationToken = default)
    {
        using var response = await _api.PostJsonAsync(
            $"payments/{paymentId}/initialize",
            new { },
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<PaymentInitializationDto>(
                cancellationToken);
    }

    public async Task<PaymentVerificationDto?> VerifyAsync(
        string reference,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(reference))
        {
            throw new ArgumentException(
                "A payment reference is required.",
                nameof(reference));
        }

        var encodedReference = Uri.EscapeDataString(reference);

        return await _api.GetAsync<PaymentVerificationDto>(
            $"payments/verify?reference={encodedReference}",
            cancellationToken);
    }
}