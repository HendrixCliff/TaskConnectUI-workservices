namespace WorkServices.Web.Features.ServiceRequests.Models;

public enum JobStatus
{
    Pending = 1,
    Assigned = 2,
    QuoteSubmitted = 3,
    QuoteApproved = 4,
    MaterialsPaid = 5,
    InProgress = 6,
    Completed = 7,
    LabourPaid = 8,
    Reviewed = 9,
    Cancelled = 10
}

public static class JobStatusExtensions
{
    public static string GetDisplayName(
        this JobStatus status)
    {
        return status switch
        {
            JobStatus.Pending => "Pending",
            JobStatus.Assigned => "Assigned",
            JobStatus.QuoteSubmitted => "Quote Submitted",
            JobStatus.QuoteApproved => "Quote Approved",
            JobStatus.MaterialsPaid => "Materials Paid",
            JobStatus.InProgress => "In Progress",
            JobStatus.Completed => "Completed",
            JobStatus.LabourPaid => "Labour Paid",
            JobStatus.Reviewed => "Reviewed",
            JobStatus.Cancelled => "Cancelled",
            _ => "Unknown"
        };
    }

    public static string GetCssClass(
        this JobStatus status)
    {
        return status switch
        {
            JobStatus.Pending => "status-pending",
            JobStatus.Assigned => "status-assigned",
            JobStatus.QuoteSubmitted => "status-quote",
            JobStatus.QuoteApproved => "status-approved",
            JobStatus.MaterialsPaid => "status-paid",
            JobStatus.InProgress => "status-progress",
            JobStatus.Completed => "status-completed",
            JobStatus.LabourPaid => "status-paid",
            JobStatus.Reviewed => "status-reviewed",
            JobStatus.Cancelled => "status-cancelled",
            _ => "status-unknown"
        };
    }
}