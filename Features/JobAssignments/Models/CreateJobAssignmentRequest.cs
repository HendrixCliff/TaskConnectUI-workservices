using System.ComponentModel.DataAnnotations;

namespace WorkServices.Web.Features.JobAssignments.Models;

public sealed class CreateJobAssignmentRequest
{
    [Required]
    public Guid ServiceRequestId { get; set; }

    [Required]
    public Guid ArtisanId { get; set; }
}