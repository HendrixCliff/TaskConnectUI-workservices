namespace WorkServices.Web.Features.Payments.Models;

public sealed class PaymentInitializationDto
{
    public string AuthorizationUrl { get; set; } = string.Empty;
}