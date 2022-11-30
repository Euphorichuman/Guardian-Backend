using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Infraestructure.MySqlDb.Context;
using Guardian.System.Infraestructure.MySqlDb.Repositories;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMySqlDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SystemDbContext>(options
                => options.UseMySql(configuration.GetConnectionString("MySqlDb"), ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlDb"))));

            return services;
        }

        public static IServiceCollection AddMySqlDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHeroesRepository, HeroesRepository>();
            services.AddScoped<IVilliansRepository, VilliansRepository>();

            return services;
        }
    }
}
