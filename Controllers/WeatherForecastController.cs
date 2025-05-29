using LaraFashionAPI.Google;
using Microsoft.AspNetCore.Mvc;

namespace LaraFashionAPI.Controllers
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
        private readonly GoogleSheetManagement _sheetManagement;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GoogleSheetManagement sheetManagement)
        {
            _logger = logger;
            _sheetManagement = sheetManagement;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Post()
        {
            _sheetManagement.UpdateSheet("Products!A2","hi");
            return Ok();
        }
    }
}
