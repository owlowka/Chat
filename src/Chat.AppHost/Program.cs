var builder = DistributedApplication.CreateBuilder(args);

// Service registration
var chatDb = builder
    .AddAzureCosmosDB("cosmos-db")
    .AddDatabase("chat")
    .RunAsEmulator();

var webApi = builder
    .AddProject<Projects.Chat_WebAPI>("web-api")
    .WithReference(chatDb);

builder
    .AddProject<Projects.Chat_WebUI>("web-ui")
    .WithReference(webApi);

builder.Build().Run();
