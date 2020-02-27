using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroServiceWebApi.Controllers
{
    /**
     * in ocelot.json 
     * UpstreamPathTemplate : 
     * is the entry point to call an api via ocelot 
     * and it will redirect the request to the actual request path of the web api[DownstreamPathTemplate]
     * we can call multiple web api at the same time and get their response aggregated
     *  "Aggregates": [
            {
              "ReRouteKeys": [
                "weatherforecasting", // is the UpstreamPathTemplate for one of the web api defined but we removed the /
                "weatherpredicting"
              ],
              "UpstreamPathTemplate": "/weatherforecastmultipleservicecall"
            }
          ]
     * 
    **/
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
