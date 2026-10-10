namespace WorkServices.Web.Features.JobAssignments.Models;

public sealed class JobAssignmentRequest
{
    public Guid ServiceRequestId { get; set; }

    public Guid ArtisanId { get; set; }
}