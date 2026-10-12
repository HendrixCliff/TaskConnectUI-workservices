namespace WorkServices.Web.Features.Quotes.Models;

public sealed class QuoteDto
{
    public Guid Id { get; set; }

    public Guid ServiceRequestId { get; set; }

    public Guid ArtisanId { get; set; }

    public decimal LabourCost { get; set; }

    public decimal MaterialsCost { get; set; }

    public decimal TotalCost { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ArtisanName { get; set; }
}