using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroServiceWebApiV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherPredictController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing2", "Bracing2", "Chilly2", "Cool2", "Mild2", "Warm2", "Balmy2", "Hot2", "Sweltering2", "Scorching2"
        };

        private readonly ILogger<WeatherPredictController> _logger;

        public WeatherPredictController(ILogger<WeatherPredictController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherPredict> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherPredict
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
