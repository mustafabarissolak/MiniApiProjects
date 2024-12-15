namespace WeatherAPI.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
        public decimal CityTemp { get; set; }
        public string CityDetail { get; set; }
    }
}
