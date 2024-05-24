var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder
    .AddProject<Projects.Chat_WebAPI>("web-api");
builder
    .AddProject<Projects.Chat_WebUI>("web-ui")
    .WithReference(webApi);

builder.Build().Run();
