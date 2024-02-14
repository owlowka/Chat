using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Configuration;
using Chat.ApplicationServices.Components.Password;
using Chat.ApplicationServices.Domain;
using Chat.ApplicationServices.Domain.User;
using Chat.ApplicationServices.Domain.User.Add;
using Chat.DataAccess;
using Chat.DataAccess.CQRS;
using Chat.WebAPI.Authentication;

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

builder.Services.AddSingleton<PasswordHasher>();

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
    options.UseInMemoryDatabase("chatDatabase");
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
