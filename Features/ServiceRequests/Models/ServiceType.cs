using System.Text.Json.Serialization;

namespace WorkServices.Web.Features.ServiceRequests.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ServiceType
{
    Carpentry = 1,
    Plumbing = 2,
    Electrical = 3,
    Painting = 4,
    Laundry = 5
}