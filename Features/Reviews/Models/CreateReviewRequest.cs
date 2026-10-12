using System.ComponentModel.DataAnnotations;

namespace WorkServices.Web.Features.Reviews.Models;

public sealed class CreateReviewRequest
{
    [Required]
    public Guid ServiceRequestId { get; set; }

    [Required]
    public Guid ArtisanId { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; } = 5;

    [Required]
    [StringLength(2000, MinimumLength = 3)]
    public string Comment { get; set; } = string.Empty;
}