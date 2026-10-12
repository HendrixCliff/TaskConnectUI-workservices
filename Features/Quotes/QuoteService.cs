using WorkServices.Web.Features.Quotes.Models;
using WorkServices.Web.Services;
namespace WorkServices.Web.Features.Quotes;

public sealed class QuoteService
{
    private readonly ApiClient _api;

    public QuoteService(ApiClient api)
    {
        _api = api;
    }

    public async Task<QuoteDto?> CreateAsync(
        CreateQuoteRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _api.PostAsync<CreateQuoteRequest, QuoteDto>(
            "quotes",
            request,
            cancellationToken);
    }

    public async Task<List<QuoteDto>> GetByServiceRequestAsync(
        Guid serviceRequestId,
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<QuoteDto>>(
            $"quotes/service-request/{serviceRequestId}",
            cancellationToken);

        return result ?? [];
    }

    public Task ApproveAsync(
        Guid quoteId,
        CancellationToken cancellationToken = default)
    {
        return _api.PostAsync(
            $"quotes/{quoteId}/approve",
            cancellationToken);
    }
}