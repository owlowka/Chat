using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Validators;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Configuration;
using Chat.ApplicationServices.Mappings;
using Chat.DataAccess;
using Chat.DataAccess.CQRS;
using Chat.WebAPI.Authentication;
using Chat.WebAPI.Configuration;

using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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


builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

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

builder.Services.AddDbContext<ChatStorageContext>(options =>
{
    DatabaseOptions? dbOptions = builder
        .Configuration
        .GetSection("Database")
        .Get<DatabaseOptions>();

    string? connectionString = builder
        .Configuration
        .GetConnectionString("ChatDatabase");

    switch (dbOptions?.Server)
    {
        case DatabaseServer.SQLite:
            options.UseSqlite(connectionString);
            break;
        case DatabaseServer.SqlServer:
            options.UseSqlServer(connectionString);
            break;
        default:
            throw new NotSupportedException($"{dbOptions?.Server} is not supported");
    }
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


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

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
