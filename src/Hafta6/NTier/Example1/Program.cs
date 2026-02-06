using Example1.Abstraction;
using Example1.Extension;
using Example1.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using NTier.Data;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.RegisterDataServices(builder.Configuration);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

app.UseExceptionHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRequestLogging();

app.Run();
