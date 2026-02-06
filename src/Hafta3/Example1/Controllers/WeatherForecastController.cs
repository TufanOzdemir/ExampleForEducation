using Example1.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("Test")]
        public IEnumerable<IWeatherForecast> Get()
        {
            var transient1 = _serviceProvider.GetKeyedService<IWeatherForecast>("Transient");
            var transient2 = _serviceProvider.GetKeyedService<IWeatherForecast>("Transient");
            return new List<IWeatherForecast> {
                transient1, transient2
            };
        }
    }
}
