using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SpaTemplates.Application.Users;
using SpaTemplates.Application.WeatherForecasts;
using SpaTemplates.Domain;

namespace SpaTemplates.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddSpaTemplatesApplication(this IServiceCollection services)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<WeatherForecast, WeatherForecastDto>();
            });

            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IWeatherForecastApplicationService, WeatherForecastApplicationService>();

            return services;
        }
    }
}
