using Chat.WebUI;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

using IChatService = Chat.WebUI.Services.Contracts.IChatService;
using HttpChatService = Chat.WebUI.Services.HttpChatService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7011/") });
builder.Services.AddScoped<IChatService, HttpChatService>();
builder.Services.AddFluentUIComponents();


await builder.Build().RunAsync();
