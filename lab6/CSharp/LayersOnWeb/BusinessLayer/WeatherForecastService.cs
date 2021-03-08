using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            this.repository = repository;
        }
        public void AddWeatherForecastModel(WeatherForecastModel weather)
        {
            repository.Add(new WeatherForecastEntity { Date = weather.Date, Summary = weather.Summary, TemperatureC = weather.TemperatureC });
        }

        public List<WeatherForecastModel> GetAllWetherForecasts()
        {
            List<WeatherForecastModel> result = new List<WeatherForecastModel>();
            foreach (var x in repository.GetAll())
            {
                result.Add(new WeatherForecastModel { Date = x.Date, Summary = x.Summary, TemperatureC = x.TemperatureC });
            }
            return result;
        }
    }
}
