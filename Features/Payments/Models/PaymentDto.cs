namespace WorkServices.Web.Features.Payments.Models;

public sealed class PaymentDto
{
    public Guid Id { get; set; }

    public Guid ServiceRequestId { get; set; }

    public decimal Amount { get; set; }

    public string? Status { get; set; }

    public string? Reference { get; set; }

    public string? AuthorizationUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}