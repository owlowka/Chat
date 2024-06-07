using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Service registration
var chatDb = builder
    .AddAzureCosmosDB("cosmos-db")
    .AddDatabase("chat")
    .RunAsEmulator(emulator =>
        emulator
            .WithGatewayPort(59232)
            .WithEnvironment("AZURE_COSMOS_EMULATOR_PARTITION_COUNT", "2")
            .WithVolume("data", "/tmp/cosmos/appdata")
            .WithEnvironment("AZURE_COSMOS_EMULATOR_ENABLE_DATA_PERSISTENCE", "true"));

var webApi = builder
    .AddProject<Projects.Chat_WebAPI>("web-api")
    .WithReference(chatDb);

builder
    .AddProject<Projects.Chat_WebUI>("web-ui")
    .WithReference(webApi);

builder.Build().Run();
