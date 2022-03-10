using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService weatherService;
        public WeatherForecastController(IWeatherForecastService weatherService)
        {
            this.weatherService = weatherService;
        }


        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = new List<WeatherForecast>();
            foreach (var w in weatherService.GetAllWetherForecasts())
            {
                result.Add(new WeatherForecast { Date = w.Date, Summary = w.Summary, TemperatureC = w.TemperatureC });
            }
            return result;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        //[Auth]
        public void Post(WeatherForecast weather)
        {
            weatherService.AddWeatherForecastModel(new WeatherForecastModel { Date = weather.Date, Summary = weather.Summary, TemperatureC = weather.TemperatureC } );
        }
    }
}
