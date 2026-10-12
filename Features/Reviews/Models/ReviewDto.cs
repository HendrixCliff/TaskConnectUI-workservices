namespace WorkServices.Web.Features.Reviews.Models;

public sealed class ReviewDto
{
    public Guid Id { get; set; }

    public Guid ServiceRequestId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ArtisanId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public string? CustomerName { get; set; }

    public string? ArtisanName { get; set; }
}