
namespace WorkServices.Web.Features.Quotes.Models;

public sealed class QuoteDto
{
    public Guid Id { get; set; }

    public Guid ServiceRequestId { get; set; }

    public decimal LabourCost { get; set; }

    public decimal MaterialCost { get; set; }

    public decimal TotalCost { get; set; }

    public string Notes { get; set; } = string.Empty;

    public bool Approved { get; set; }
}
