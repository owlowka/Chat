using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Mappings;
using Chat.DataAccess;
using Chat.DataAccess.CQRS;

using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));

builder.Services.AddControllers();

builder.Services.AddDbContext<ChatStorageContext>(options =>
    options
        .UseSqlite(
            builder
               .Configuration
               .GetConnectionString("ChatDatabase")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
