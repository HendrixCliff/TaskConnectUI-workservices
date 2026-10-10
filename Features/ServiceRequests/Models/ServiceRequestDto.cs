using System.Text.Json.Serialization;

namespace WorkServices.Web.Features.ServiceRequests.Models;

public sealed class ServiceRequestDto
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid? ArtisanId { get; set; }

    public int ServiceType { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public JobStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CustomerName { get; set; }

    public string? ArtisanName { get; set; }
}

