using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using WorkServices.Web;
using WorkServices.Web.Auth;
using WorkServices.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var configuredApiUrl =
    builder.Configuration["WorkServicesApi:BaseUrl"]
    ?? "https://taskconnect.duckdns.org/api/";

Uri apiBaseUri;

if (Uri.TryCreate(
        configuredApiUrl,
        UriKind.Absolute,
        out var absoluteUri))
{
    apiBaseUri = absoluteUri;
}
else
{
    apiBaseUri = new Uri(
        new Uri(builder.HostEnvironment.BaseAddress),
        configuredApiUrl);
}

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = apiBaseUri
});

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<WorkServicesAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(
    services => services.GetRequiredService<
        WorkServicesAuthenticationStateProvider>());

await builder.Build().RunAsync();

public sealed class BrowserRequestCredentialsHandler
    : DelegatingHandler
{
    public BrowserRequestCredentialsHandler()
        : base(new HttpClientHandler())
    {
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(
            BrowserRequestCredentials.Include);

        return base.SendAsync(request, cancellationToken);
    }
}
