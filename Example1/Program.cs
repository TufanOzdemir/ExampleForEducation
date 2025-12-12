using Example1;
using Example1.Abstraction;
using Example1.Extension;
using Example1.Models;
using Example1.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
// DI Example
// builder.Services.AddTransient<WeatherForecast>();
// builder.Services.AddScoped<WeatherForecast>();
builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();

// Keyed
/*builder.Services.AddKeyedTransient<IWeatherForecast, WeatherForecast>("Transient");
builder.Services.AddKeyedScoped<IWeatherForecast, WeatherForecast>("Scoped");
builder.Services.AddKeyedSingleton<IWeatherForecast, WeatherForecast>("Singleton");*/


/*builder.Configuration
    .AddJsonFile("custom.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();*/


// var t = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<MarketplaceDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        //.UseLazyLoadingProxies()
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});

builder.Logging.ClearProviders();
builder.Host.UseNLog();

logger.Debug("init main");
logger.Info("Application Starting Up");
logger.Warn("Application Warning");
logger.Error("Application Error");

var app = builder.Build();

app.UseExceptionHandling();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// .NET 6 minimal API endpoint
app.MapGet("/", () => "Hello World!");
app.MapGet("/api/calculate/{a}+{b}", (int a, int b) => { return a + b; });
app.MapGet("/api/calculate/{a}-{b}", (int a, int b) => { return a - b; });
app.MapGet("/api/calculate/{a}/{b}", (int a, int b) => { return a / b; });
app.MapGet("/api/calculate/{a}*{b}", (int a, int b) => { return a * b; });

app.UseRequestLogging();

//app.Use(async (ctx, next) =>
//{
//    Console.WriteLine("Use - 1");
//    await next();
//    Console.WriteLine("Use - 1 After");
//});

app.Run();
