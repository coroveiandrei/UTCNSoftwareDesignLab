﻿using System;

namespace DataAccess
{
    public class WeatherForecastEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
