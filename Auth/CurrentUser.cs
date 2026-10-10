namespace WorkServices.Web.Auth;

public sealed class CurrentUser
{
    public string Id { get; init; } = string.Empty;

    public string FullName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;

    public bool IsAuthenticated =>
        !string.IsNullOrWhiteSpace(Id);
}