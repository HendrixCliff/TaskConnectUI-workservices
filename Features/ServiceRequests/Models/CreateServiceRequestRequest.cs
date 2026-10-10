namespace WorkServices.Web.Features.ServiceRequests.Models;

public sealed class CreateServiceRequestRequest
{
    public Guid CustomerId { get; set; }

    public int ServiceType { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}