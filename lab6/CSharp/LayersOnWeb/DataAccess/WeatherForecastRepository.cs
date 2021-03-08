using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherDbContext weatherDbContext;
        public WeatherForecastRepository(WeatherDbContext weatherDbContext)
        {
            this.weatherDbContext = weatherDbContext;
        } 
        public void Add(WeatherForecastEntity weather)
        {
            weatherDbContext.Add(weather);
            weatherDbContext.SaveChanges();
        }

        public List<WeatherForecastEntity> GetAll()
        {
            return weatherDbContext.WeatherEntities.ToList();
        }
    }
}
