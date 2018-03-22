using Microsoft.Extensions.DependencyInjection;
using SpaTemplates.Application.Users;

namespace SpaTemplates.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddSpaTemplatesApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserApplicationService, UserApplicationService>();

            return services;
        }
    }
}
