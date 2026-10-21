using System.Collections.Generic;

namespace WorkServices.Web.Features.Payments.Models;

public sealed class PaymentListResponse
{
    public List<PaymentDto> Items { get; set; } = [];

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }
}
