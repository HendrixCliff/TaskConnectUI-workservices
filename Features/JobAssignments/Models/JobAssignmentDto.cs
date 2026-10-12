namespace WorkServices.Web.Features.JobAssignments.Models;

public sealed class JobAssignmentDto
{
    public Guid Id { get; set; }

    public Guid ServiceRequestId { get; set; }

    public Guid? ArtisanId { get; set; }

    public Guid? CustomerId { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ArtisanName { get; set; }

    public string? CustomerName { get; set; }

    public string? ServiceDescription { get; set; }
}