using System.ComponentModel.DataAnnotations;

namespace WorkServices.Web.Features.Quotes.Models;

public sealed class CreateQuoteRequest
{
    [Required]
    public Guid ServiceRequestId { get; set; }

    [Range(0, 1000000000,
        ErrorMessage = "Labour cost cannot be negative.")]
    public decimal LabourCost { get; set; }

    [Range(0, 1000000000,
        ErrorMessage = "Materials cost cannot be negative.")]
    public decimal MaterialsCost { get; set; }

    [Required]
    [StringLength(2000, MinimumLength = 3)]
    public string Description { get; set; } = string.Empty;
}