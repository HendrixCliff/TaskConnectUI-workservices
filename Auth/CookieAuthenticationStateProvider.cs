using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace WorkServices.Web.Auth;

public sealed class CookieAuthenticationStateProvider
    : AuthenticationStateProvider
{
    private readonly AuthService _authService;

    private static readonly ClaimsPrincipal Anonymous =
        new(new ClaimsIdentity());

    public CookieAuthenticationStateProvider(
        AuthService authService)
    {
        _authService = authService;

        _authService.AuthenticationStateChanged +=
            HandleAuthenticationStateChanged;
    }

    public override async Task<AuthenticationState>
        GetAuthenticationStateAsync()
    {
        try
        {
            var user = await _authService.GetCurrentUserAsync();

            if (user is null)
                return new AuthenticationState(Anonymous);

            var claims = new List<Claim>
            {
                new(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new(
                    ClaimTypes.Name,
                    user.FullName),

                new(
                    ClaimTypes.Email,
                    user.Email),

                new(
                    ClaimTypes.Role,
                    user.Role)
            };

            var identity = new ClaimsIdentity(
                claims,
                authenticationType: "Cookie");

            return new AuthenticationState(
                new ClaimsPrincipal(identity));
        }
        catch
        {
            return new AuthenticationState(Anonymous);
        }
    }

    private void HandleAuthenticationStateChanged(
        object? sender,
        EventArgs e)
    {
        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }

    public void Dispose()
    {
        _authService.AuthenticationStateChanged -=
            HandleAuthenticationStateChanged;
    }
}