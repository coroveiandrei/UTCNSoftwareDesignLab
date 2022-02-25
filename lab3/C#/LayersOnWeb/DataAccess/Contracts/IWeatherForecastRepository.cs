using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IWeatherForecastRepository
    {
        List<WeatherForecastEntity> GetAll();
        void Add(WeatherForecastEntity weather);
    }
}
