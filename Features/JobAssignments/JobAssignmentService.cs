
using WorkServices.Web.Features.JobAssignments.Models;
using WorkServices.Web.Services;

namespace WorkServices.Web.Features.JobAssignments;

public sealed class JobAssignmentService
{
    private readonly ApiClient _api;

    public JobAssignmentService(ApiClient api)
    {
        _api = api;
    }

    public async Task<List<ArtisanJobDto>> GetMyJobsAsync(
        CancellationToken cancellationToken = default)
    {
        var jobs = await _api.GetAsync<List<ArtisanJobDto>>(
            "artisans/jobs",
            cancellationToken);

        return jobs ?? [];
    }

    public async Task AssignAsync(
    CreateJobAssignmentRequest request,
    CancellationToken cancellationToken = default)
{
    await _api.PostAsync<object?>(
        "job-assignments",
        request,
        cancellationToken);
}

    public Task AcceptAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        return PostActionAsync(
            $"job-assignments/{assignmentId}/accept",
            cancellationToken);
    }

    public Task RejectAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        return PostActionAsync(
            $"job-assignments/{assignmentId}/reject",
            cancellationToken);
    }

    public Task StartAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        return PostActionAsync(
            $"job-assignments/{assignmentId}/start",
            cancellationToken);
    }

    public Task CompleteAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        return PostActionAsync(
            $"job-assignments/{assignmentId}/complete",
            cancellationToken);
    }

   private async Task PostActionAsync(
    string endpoint,
    CancellationToken cancellationToken)
{
    await _api.PostAsync<object?>(
        endpoint,
        null,
        cancellationToken);
}
}
