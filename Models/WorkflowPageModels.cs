namespace WorkServices.Web.Models;



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
