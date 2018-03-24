using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SpaTemplates.Application.Users;
using SpaTemplates.Application.WeatherForecasts;

namespace SpaTemplates.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddSpaTemplatesApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new ApplicationMappingProfile()));
            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IWeatherForecastApplicationService, WeatherForecastApplicationService>();

            return services;
        }
    }
}
