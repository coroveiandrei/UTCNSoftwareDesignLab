using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IRepository repository;

        public WeatherForecastService(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddWeatherForecastModel(WeatherForecastModel weather)
        {
            repository.Add(new WeatherForecastEntity { Date = weather.Date, Summary = weather.Summary, TemperatureC = weather.TemperatureC });
            repository.SaveChanges();
        }

        public List<WeatherForecastModel> GetAllWetherForecasts()
        {
            List<WeatherForecastModel> result = new List<WeatherForecastModel>();
            foreach (var x in repository.GetAll<WeatherForecastEntity>())
            {
                result.Add(new WeatherForecastModel { Date = x.Date, Summary = x.Summary, TemperatureC = x.TemperatureC });
            }
            return result;
        }
    }
}
