using Chat.WebUI;
using Chat.WebUI.Services;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        //Aspire does not support service discovery for WebAssembly Blazor https://github.com/dotnet/aspire/issues/1659
        //builder.Services.AddServiceDiscovery();

        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            // Turn on resilience by default
            http.AddStandardResilienceHandler();

            // Turn on service discovery by default
            //http.AddServiceDiscovery();
        });

        builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7011")
            });
        builder.Services.AddScoped<IChatService, HttpChatService>();
        builder.Services.AddFluentUIComponents();

        builder.Services.AddMsalAuthentication(options =>
        {
            builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.LoginMode = "redirect";
            options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
            //options.ProviderOptions.DefaultAccessTokenScopes.Add("profile");
            options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
        });

        await builder.Build().RunAsync();
    }
}