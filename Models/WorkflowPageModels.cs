namespace WorkServices.Web.Models;

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
}

public sealed class PaymentDto
{
    public Guid Id { get; set; }
    public Guid ServiceRequestId { get; set; }
    public decimal Amount { get; set; }
    public string? Status { get; set; }
    public string? Reference { get; set; }
    public string? AuthorizationUrl { get; set; }
}

public sealed class CreateReviewRequest
{
    public Guid ServiceRequestId { get; set; }
    public Guid ArtisanId { get; set; }
    public int Rating { get; set; } = 5;
    public string Comment { get; set; } = string.Empty;
}

public sealed class AdminUserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Status { get; set; }
    public string? ServiceType { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public sealed class UpdateArtisanProfileRequest
{
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
