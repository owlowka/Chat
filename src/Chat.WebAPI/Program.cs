
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Configuration;
using Chat.ApplicationServices.Components.Password;
using Chat.DataAccess;
using Chat.Domain.CQRS;
using Chat.Domain.CQRS.Database;
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


builder.Services.AddAuthentication(BasicAuthenticationHandler.SchemaName)
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
    BasicAuthenticationHandler.SchemaName, null);

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
builder.Services.AddDbContext<ChatStorageContext>(options =>
    options.UseInMemoryDatabase("chatDatabase"));
//2
builder.Services.AddAuthorization();

//3
builder.Services
    .AddIdentityApiEndpoints<IdentityUser<Guid>>()
    .AddEntityFrameworkStores<ChatStorageContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(/*c => c.SwaggerEndpoint("swagger/v1/swagger.json", "Chat")*/);
}

app.UseCors(policy =>
    policy
        .WithOrigins("http://localhost:5222", "https://localhost:7106")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapIdentityApi<IdentityUser<Guid>>();

app.MapControllers()
   .RequireAuthorization();


await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
{
    ISender sender = scope.ServiceProvider.GetRequiredService<IMediator>();

    IEnumerable<AddUserRequest> userRequests = RandomNameGenerator.Names
        .Select(userName => new AddUserRequest
        {
            Username = userName,
        });

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
}

app.Run();

public class RandomNameGenerator
{
    public static readonly string[] Names = ["Alice", "Bob"];

    public static string GenerateRandomName() => Random.Shared.GetItems(Names, 1)[0];
}