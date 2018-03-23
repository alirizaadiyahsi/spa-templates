namespace SpaTemplates.Domain
{
    public class WeatherForecast : BaseEntity
    {
        public string DateFormatted { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}