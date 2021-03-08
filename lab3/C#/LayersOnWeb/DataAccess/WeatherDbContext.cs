using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
       : base(options)
        {
        }
        public DbSet<WeatherForecastEntity> WeatherEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=dbweather;Trusted_Connection=True;");
        }
    }
}
