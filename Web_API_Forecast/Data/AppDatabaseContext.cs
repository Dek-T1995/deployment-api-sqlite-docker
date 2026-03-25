using Microsoft.EntityFrameworkCore;
using Web_API_Forecast.Models;

namespace Web_API_Forecast.Data
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<WeatherData> WeatherData { get; set; }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> contexOptions)
            : base(contexOptions) 
        { 
        }
    }
}
