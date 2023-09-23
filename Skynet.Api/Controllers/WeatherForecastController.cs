using Microsoft.AspNetCore.Mvc;

namespace Skynet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var list = new List<WeatherForecast>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                    TemperatureC = Random.Shared.Next(-20, 55)
                });
            }
            return list;
           //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}