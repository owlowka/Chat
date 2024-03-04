using Chat.WebUI;
using Chat.WebUI.Services;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

using IMessageService = Chat.WebUI.Services.Contracts.IMessageService;
using MessageService = Chat.WebUI.Services.MessageService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7011/") });
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddFluentUIComponents();


await builder.Build().RunAsync();
