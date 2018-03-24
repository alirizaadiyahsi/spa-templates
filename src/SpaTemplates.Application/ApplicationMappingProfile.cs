using AutoMapper;
using SpaTemplates.Application.WeatherForecasts;
using SpaTemplates.Domain;

namespace SpaTemplates.Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>();
        }
    }
}