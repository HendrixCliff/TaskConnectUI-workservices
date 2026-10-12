using WorkServices.Web.Features.Reviews.Models;
using WorkServices.Web.Services;
namespace WorkServices.Web.Features.Reviews;

public sealed class ReviewService
{
    private readonly ApiClient _api;

    public ReviewService(ApiClient api)
    {
        _api = api;
    }

    public async Task<ReviewDto?> CreateAsync(
        CreateReviewRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _api.PostAsync<CreateReviewRequest, ReviewDto>(
            "reviews",
            request,
            cancellationToken);
    }

    public async Task<List<ReviewDto>> GetByArtisanAsync(
        Guid artisanId,
        CancellationToken cancellationToken = default)
    {
        var result = await _api.GetAsync<List<ReviewDto>>(
            $"reviews/artisan/{artisanId}",
            cancellationToken);

        return result ?? [];
    }
}