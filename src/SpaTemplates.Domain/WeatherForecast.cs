namespace SpaTemplates.Domain
{
    public class WeatherForecast : BaseEntity
    {
        public string DateFormatted { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        //todo: move following prop to dto
        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}