using Aspire.Microsoft.EntityFrameworkCore.Cosmos;

using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Configuration;
using Chat.ApplicationServices.Components.Password;
using Chat.DataAccess;
using Chat.Domain.Conversation.Add;
using Chat.Domain.CQRS;
using Chat.Domain.CQRS.Database;
using Chat.Domain.Message;
using Chat.Domain.Message.Add;
using Chat.Domain.User;
using Chat.Domain.User.Add;
using Chat.WebAPI.Authentication;

using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

using NLog.Web;

using RestSharp;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Host.UseNLog();

builder.Services
    .AddOptions<WeatherClientOptions>()
    .BindConfiguration("WeatherClient");

// Add services to the container.
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<AddUserRequestValidator>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//builder.Services.AddAuthentication(BasicAuthenticationHandler.SchemaName)
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
//    BasicAuthenticationHandler.SchemaName, null);

builder.Services.AddSingleton<PasswordHasher>();

builder.Services.AddTransient<ICommandExecutor, DbCommandExecutor>();

builder.Services.AddTransient<IQueryExecutor, DbQueryExecutor>();

builder.Services.AddTransient<IOpenWeatherClient, WeatherClient>();

builder.Services.AddSingleton<IRestClient>(serviceProvider =>
{
    IOptions<WeatherClientOptions> options = serviceProvider.GetRequiredService<IOptions<WeatherClientOptions>>();

    WeatherClientOptions? weatherClientOptions = options.Value;

    var client = new RestClient(weatherClientOptions.BaseUrl);

    client.AddDefaultQueryParameter("appid", weatherClientOptions.ApiKey);

    return client;
});

builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));

builder.Services.AddControllers();

//1
builder.AddCosmosDbContext<ChatStorageContext>("cosmos-db", "chat");
//builder.Services.AddDbContext<ChatStorageContext>(options =>
    //options.UseInMemoryDatabase("chatDatabase"));

//2
builder.Services.AddAuthorization();

//3
//builder.Services
//    .AddIdentityApiEndpoints<IdentityUser<Guid>>()
//    .AddEntityFrameworkStores<ChatStorageContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(/*c => c.SwaggerEndpoint("swagger/v1/swagger.json", "Chat")*/);
}

app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        //.WithOrigins("http://localhost:5222", "https://localhost:7106")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapIdentityApi<IdentityUser<Guid>>();

//app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager,
//    [FromBody] object empty) =>
//{
//    if (empty != null)
//    {
//        await signInManager.SignOutAsync();
//        return Results.Ok();
//    }
//    return Results.Unauthorized();
//})
//.WithOpenApi()
//.RequireAuthorization();

app.MapControllers();

//.RequireAuthorization();

await InitializeDatabase(app);

app.Run();

static async Task InitializeDatabase(WebApplication app)
{
    await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
    {
        DbContext context = scope.ServiceProvider.GetRequiredService<ChatStorageContext>();

        var database = context.Database;

        await WaitForEmulator(scope, database);

        bool wasCreated = context.Database.EnsureCreated();

        if (wasCreated is false)
        {
            return;
        }

        ISender sender = scope.ServiceProvider.GetRequiredService<IMediator>();

        IEnumerable<AddUserRequest> userRequests = RandomNameGenerator.Names
            .Select(userName => new AddUserRequest
            {
                Username = userName,
            });

        //UserManager manager;

        //Check Identity how to regiseter user

        foreach (AddUserRequest? request in userRequests)
        {
            await sender.Send(request);
        }

        IEnumerable<AddMessageRequest> requests = Enumerable
            .Range(0, 10)
            .Select(i => new AddMessageRequest
            {
                Content = $"Test {i}",
                Sender = RandomNameGenerator.GenerateRandomName(),
                CreatedAt = DateTime.UtcNow
            });

        foreach (AddMessageRequest? request in requests)
        {
            await sender.Send(request);
        }

        IEnumerable<AddConversationRequest> conversationRequests = RandomNameGenerator.Names
            .Select(userName => new AddConversationRequest
            {
                Name = userName,
                Messages =
                [
                    new MessageModel()
                    {
                        Content = "Content",
                        SenderName = userName,
                        CreatedAt = DateTime.Now
                    }
                ],
                Users =
                [
                    new UserModel
                    {
                        Username = userName
                    },
                    new UserModel
                    {
                        Username = "Roksana Duda"
                    }
                ]
            });

        foreach (AddConversationRequest? request in conversationRequests)
        {
            await sender.Send(request);
        }
    }

    static async Task WaitForEmulator(AsyncServiceScope scope, Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade database)
    {
        if (database.IsCosmos())
        {
            var cosmosClient = database.GetCosmosClient();

            ILogger logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            bool retry = true;
            do
            {
                logger.LogInformation("Waiting for database");

                try
                {
                    var account = await cosmosClient.ReadAccountAsync();
                    retry = false;
                    logger.LogInformation("Database ready");
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            } while (retry);
        }
    }
}

public class RandomNameGenerator
{
    public static readonly string[] Names = ["Roksana Duda", "Bob", "Alice"];

    public static string GenerateRandomName() => Random.Shared.GetItems(Names, 1)[0];
}

//What next? API must require Authentication Token
//The token must be validated before particular request
//GET/Conversation endpoint must requre token to validation
