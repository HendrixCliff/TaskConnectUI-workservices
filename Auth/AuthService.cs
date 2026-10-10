using System.Net;
using WorkServices.Web.Models;
using WorkServices.Web.Models.Auth;
using WorkServices.Web.Services;

namespace WorkServices.Web.Auth;

public sealed class AuthService
{
    private readonly ApiClient _api;

    private CurrentUser? _user;
    private bool _currentUserLoaded;

    public event EventHandler? AuthenticationStateChanged;

    public CurrentUser? User => _user;

    public AuthService(ApiClient api)
    {
        _api = api;
    }

    public async Task<CurrentUser?> GetCurrentUserAsync(
        CancellationToken cancellationToken = default)
    {
        if (_currentUserLoaded)
        {
            return _user;
        }

        _currentUserLoaded = true;

        try
        {
            _user = await _api.GetAsync<CurrentUser>(
                "auth/me",
                cancellationToken);

            return _user;
        }
        catch (ApiException ex) when (
            ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            _user = null;
            return null;
        }
        catch
        {
            _user = null;
            return null;
        }
    }

    public async Task LoginAsync(
        LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response = await _api.PostJsonAsync(
            "auth/login",
            request,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(
                response.StatusCode,
                body);
        }

        _user = null;
        _currentUserLoaded = false;

        await GetCurrentUserAsync(cancellationToken);

        AuthenticationStateChanged?.Invoke(
            this,
            EventArgs.Empty);
    }

    public async Task RefreshAsync(
        CancellationToken cancellationToken = default)
    {
        using var response = await _api.PostJsonAsync<object?>(
            "auth/refresh",
            null,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _user = null;
            _currentUserLoaded = true;

            AuthenticationStateChanged?.Invoke(
                this,
                EventArgs.Empty);

            return;
        }

        _user = null;
        _currentUserLoaded = false;

        await GetCurrentUserAsync(cancellationToken);

        AuthenticationStateChanged?.Invoke(
            this,
            EventArgs.Empty);
    }

    public async Task LogoutAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _api.PostAsync(
                "auth/logout",
                cancellationToken);
        }
        finally
        {
            _user = null;
            _currentUserLoaded = true;

            AuthenticationStateChanged?.Invoke(
                this,
                EventArgs.Empty);
        }
    }

    public void MarkSignedOut()
    {
        _user = null;
        _currentUserLoaded = true;

        AuthenticationStateChanged?.Invoke(
            this,
            EventArgs.Empty);
    }

    public async Task RegisterCustomerAsync(
        RegisterCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        await _api.PostAsync(
            "auth/register/customer",
            request,
            cancellationToken);
    }

    public async Task RegisterArtisanAsync(
        RegisterArtisanRequest request,
        CancellationToken cancellationToken = default)
    {
        await _api.PostAsync(
            "auth/register/artisan",
            request,
            cancellationToken);
    }

    public async Task ConfirmEmailAsync(
        Guid userId,
        string token,
        CancellationToken cancellationToken = default)
    {
        var uri =
            $"auth/confirm-email" +
            $"?userId={Uri.EscapeDataString(userId.ToString())}" +
            $"&token={Uri.EscapeDataString(token)}";

        using var response = await _api.GetRawAsync(
            uri,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(
                cancellationToken);

            throw new ApiException(
                response.StatusCode,
                body);
        }
    }
}