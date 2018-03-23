using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SpaTemplates.EntityFrameworkCore
{
    public static class EntityFrameworkCoreServiceExtensions
    {
        public static IServiceCollection AddSpaTemplatesEntityFrameworkCore(this IServiceCollection services)
        {
            //services.AddTransient<IRepositoryFactory, UnitOfWork>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<SpaTemplatesContext>();

            return services;
        }
    }
}