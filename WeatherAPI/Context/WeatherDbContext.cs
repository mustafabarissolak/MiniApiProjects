using Microsoft.EntityFrameworkCore;
using WeatherAPI.Entities;

namespace WeatherAPI.Context
{
    public class WeatherDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BARIS\\SQLEXPRESS;initial catalog=DbWeather;Trusted_Connection=True;integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<City> Cities { get; set; }

    }
}
