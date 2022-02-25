using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IWeatherForecastService
    {
        List<WeatherForecastModel> GetAllWetherForecasts();
        void AddWeatherForecastModel(WeatherForecastModel weather);
    }
}
