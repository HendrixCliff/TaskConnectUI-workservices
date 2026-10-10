using System.Net.Http.Json;
using WorkServices.Web.Features.JobAssignments.Models;

namespace WorkServices.Web.Features.JobAssignments;

public sealed class JobAssignmentService
{
    private readonly HttpClient _httpClient;

    public JobAssignmentService(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AssignAsync(
        JobAssignmentRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsJsonAsync(
                "job-assignments",
                request,
                cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task AcceptAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsync(
                $"job-assignments/{assignmentId}/accept",
                null,
                cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task RejectAsync(
        Guid assignmentId,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsync(
                $"job-assignments/{assignmentId}/reject",
                null,
                cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task StartAsync(
        Guid serviceRequestId,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsync(
                $"job-assignments/{serviceRequestId}/start",
                null,
                cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task CompleteAsync(
        Guid serviceRequestId,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsync(
                $"job-assignments/{serviceRequestId}/complete",
                null,
                cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}