using Example1.Abstraction;
using System;

namespace Example1
{
    public class WeatherForecast : IWeatherForecast
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public Guid Id { get; } = Guid.NewGuid();

        public WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(Random.Shared.Next(1, 10)));
            TemperatureC = Random.Shared.Next(-20, 55);
            Summary = Summaries[Random.Shared.Next(Summaries.Length)];
        }
    }
}
