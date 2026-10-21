
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        if (serviceRequestId == Guid.Empty)
        {
            throw new ArgumentException(
                "A valid service request ID is required.",
                nameof(serviceRequestId));
        }

        var result = await _api.GetAsync<PaymentListResponse>(
            $"payments/service-request/{serviceRequestId}",
            cancellationToken);

        return result?.Items ?? [];
    }

    public async Task<string> InitializePaymentAsync(
        Guid serviceRequestId,
        PaymentType paymentType,
        CancellationToken cancellationToken = default)
    {
        if (serviceRequestId == Guid.Empty)
        {
            throw new ArgumentException(
                "A valid service request ID is required.",
                nameof(serviceRequestId));
        }

       if (!Enum.IsDefined(typeof(PaymentType), paymentType))
        {
            throw new ArgumentOutOfRangeException(
                nameof(paymentType),
                paymentType,
                "Unsupported payment type.");
        }

var endpoint =
    $"payments/service-request/{serviceRequestId}/initialize" +
    $"?paymentType={(int)paymentType}";
        var result = await _api.PostAsync<object, PaymentInitializationDto>(
            endpoint,
            new { },
            cancellationToken);

        if (string.IsNullOrWhiteSpace(result?.AuthorizationUrl))
        {
            throw new InvalidOperationException(
                "The payment API did not return a checkout URL.");
        }

        return result.AuthorizationUrl;
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
