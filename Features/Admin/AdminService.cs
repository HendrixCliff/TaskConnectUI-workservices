
using WorkServices.Web.Features.Admin.Models;
using WorkServices.Web.Services;

namespace WorkServices.Web.Features.Admin;

public sealed class AdminService
{
    private readonly ApiClient _api;

    public AdminService(ApiClient api)
    {
        _api = api;
    }

    public async Task<List<ServiceRequestForAssignmentDto>>
        GetServiceRequestsAsync(
            CancellationToken cancellationToken = default)
    {
        var requests =
            await _api.GetAsync<List<ServiceRequestForAssignmentDto>>(
                "admin/service-requests",
                cancellationToken);

        return requests ?? [];
    }
}
