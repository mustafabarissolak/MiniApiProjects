using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Context;
using WeatherAPI.Entities;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherDbContext context = new WeatherDbContext();

        [HttpGet]
        public IActionResult GetWeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Yeni şehir eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int cityId)
        {
            var value = context.Cities.Find(cityId);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir silindi");
        }

        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.CityDetail = city.CityDetail;
            value.CityCountry = city.CityCountry;
            value.CityTemp = city.CityTemp;
            context.SaveChanges();
            return Ok($"{city.CityId} id'li şehir Güncellendi");
        }

        [HttpGet("GetByIdWeatherCityList")]
        public IActionResult GetByIdWeatherCityList(int id)
        {
            var values = context.Cities.Find(id);
            return Ok(values);
        }

        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var value = context.Cities.Count();
            return Ok(value);
        }

        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value = context.Cities.OrderByDescending(x => x.CityTemp).Select(y=>y.CityName).FirstOrDefault();
            return Ok(value);
        }

        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.CityTemp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }
    }
}
