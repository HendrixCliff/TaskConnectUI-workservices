
namespace WorkServices.Web.Features.JobAssignments.Models;

public sealed class ArtisanJobDto
{
    public Guid AssignmentId { get; set; }

    public Guid ServiceRequestId { get; set; }

    public string Address { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Accepted { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string ServiceType { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public decimal EstimatedCost { get; set; }
}
