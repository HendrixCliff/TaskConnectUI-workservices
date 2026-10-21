namespace WorkServices.Web.Features.JobAssignments.Models;

public sealed class ArtisanJobDto
{
    public Guid AssignmentId { get; set; }

    public Guid ServiceRequestId { get; set; }

    public string ServiceType { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? CustomerName { get; set; }

    public decimal EstimatedCost { get; set; }

    public bool Accepted { get; set; }

    public string Status { get; set; } = string.Empty;
}